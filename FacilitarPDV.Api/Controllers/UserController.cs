using FacilitarPDV.Domain.Commands.Handlers;
using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacilitarPDV.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserHandler _handler;
        private readonly IUserRepository _repository;

        public UserController(UserHandler handler, IUserRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/user")]
        public async Task<IActionResult> Insert([FromBody] UserCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }
    }
}
