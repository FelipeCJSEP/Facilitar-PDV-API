using FacilitarPDV.Api.Security;
using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Entities;
using FacilitarPDV.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FacilitarPDV.Api.Controllers
{
    public class AccountController : BaseController
    {
        private User _user;
        private readonly IUserRepository _repository;
        private readonly TokenOptions _tokenOptions;
        private readonly JsonSerializerSettings _serializerSettings;

        private static void ThrowIfInvalidOptions(TokenOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maior que zero", nameof(TokenOptions.ValidFor));

            if (options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(TokenOptions.SigningCredentials));

            if (options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(TokenOptions.JtiGenerator));
        }

        public AccountController(IOptions<TokenOptions> jwtOptions, IUserRepository repository)
        {
            _repository = repository;
            _tokenOptions = jwtOptions.Value;

            ThrowIfInvalidOptions(_tokenOptions);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        private Task<ClaimsIdentity> GetClaims(AuthenticateUserCommandHandler command)
        {
            User user = _repository.GetByUsername(command.Username);

            if (user == null || !user.Authenticate(command.Username, command.Password))
                return Task.FromResult<ClaimsIdentity>(null);
            else
            {
                _user = user;

                return Task.FromResult(new ClaimsIdentity(
                    new GenericIdentity(user.Username, "Token"),
                    new[]
                    {
                        new Claim("FacilitarPDV", "User")
                    }));
            }
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/authenticate")]
        public async Task<IActionResult> Post([FromForm] AuthenticateUserCommandHandler command)
        {
            if (command == null)
                return await Response(null, new List<string> { "Usuário ou senha inválidos" } );

            ClaimsIdentity identity = await GetClaims(command);

            if (identity == null)
                return await Response(null, new List<string> { "Usuário ou senha inválidos" });

            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, command.Username),
                new Claim(JwtRegisteredClaimNames.NameId, command.Username),
                new Claim(JwtRegisteredClaimNames.Email, command.Username),
                new Claim(JwtRegisteredClaimNames.Sub, command.Username),
                new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("FacilitarPDV")
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims.AsEnumerable(),
                notBefore: _tokenOptions.NotBefore,
                expires: _tokenOptions.Expiration,
                signingCredentials: _tokenOptions.SigningCredentials);

            string encodedJWT = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJWT,
                expires = (int)_tokenOptions.ValidFor.TotalSeconds,
                usuario = new
                {
                    id = _user.Id,
                    nome = _user.Name.FullName(),
                    nomeUsuario = _user.Username
                }
            };

            string json = JsonConvert.SerializeObject(response, _serializerSettings);

            return new OkObjectResult(json);
        }
    }
}
