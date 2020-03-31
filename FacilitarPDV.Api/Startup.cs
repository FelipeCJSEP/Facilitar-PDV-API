using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FacilitarPDV.Api.Security;
using FacilitarPDV.Infra.Context;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Infra.Repositories;
using FacilitarPDV.Domain.Commands.Handlers;
using FacilitarPDV.Domain.Entities;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using FacilitarPDV.Domain.Entities.TaxInformations;
using FacilitarPDV.Shared.Entities;
using System.Diagnostics;

namespace FacilitarPDV.Api
{
    public class Startup
    {
        private const string ISSUER = "3cdbf1b5";
        private const string AUDIENCE = "bc6ff62fb7b2";
        private const string SECRET_KEY = "3cdbf1b5-00f4-44b9-ad61-bc6ff62fb7b2";

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env)
        {
            Process mongodProcess = new Process()
            {
                StartInfo = new ProcessStartInfo("C:/dev/FacilitarPDV/MongoDB/bin/mongod.exe")
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };

            mongodProcess.Start();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = ISSUER,

                        ValidateAudience = true,
                        ValidAudience = AUDIENCE,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = _signingKey,

                        RequireExpirationTime = true,
                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.Zero
                    };
                });

            services
                .AddMvc(config =>
                {
                    AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddJsonOptions(options =>
                {
                    // impede que valores nulos apareçam nas requisições JSON
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddCors();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim("FacilitarPDV", "User"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("FacilitarPDV", "Admin"));
            });

            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddTransient<DataContext, DataContext>();

            services.AddTransient<ICashRepository, CashRepository>();
            services.AddTransient<ICashClosingRepository, CashClosingRepository>();
            services.AddTransient<ICashMovementRepository, CashMovementRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductUnitRepository, ProductUnitRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<CashHandler, CashHandler>();
            services.AddTransient<CashClosingHandler, CashClosingHandler>();
            services.AddTransient<CashMovementHandler, CashMovementHandler>();
            services.AddTransient<CategoryHandler, CategoryHandler>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddTransient<OrderHandler, OrderHandler>();
            services.AddTransient<PaymentMethodHandler, PaymentMethodHandler>();
            services.AddTransient<ProductHandler, ProductHandler>();
            services.AddTransient<ProductUnitHandler, ProductUnitHandler>();
            services.AddTransient<UserHandler, UserHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseMvc();

            BsonClassMap.RegisterClassMap<Cash>();
            BsonClassMap.RegisterClassMap<CashClosing>();
            BsonClassMap.RegisterClassMap<CashMovement>();
            BsonClassMap.RegisterClassMap<Category>();
            BsonClassMap.RegisterClassMap<ComponentProduct>();
            BsonClassMap.RegisterClassMap<Customer>();
            BsonClassMap.RegisterClassMap<Order>();
            BsonClassMap.RegisterClassMap<OrderItem>();
            BsonClassMap.RegisterClassMap<PaymentMethod>();
            BsonClassMap.RegisterClassMap<Product>();
            BsonClassMap.RegisterClassMap<ProductUnit>();
            BsonClassMap.RegisterClassMap<Sale>();
            BsonClassMap.RegisterClassMap<SalePayment>();
            BsonClassMap.RegisterClassMap<User>();
            BsonClassMap.RegisterClassMap<UserType>();
            
            BsonClassMap.RegisterClassMap<TaxInformation>(cm =>
            {
                cm.SetIsRootClass(true);
                cm.MapIdMember(m => m.Code);
                cm.MapIdMember(m => m.Description);
            });

            BsonClassMap.RegisterClassMap<TaxInformationCest>(cm => cm.MapCreator(c => new TaxInformationCest(c.Code, c.Description)));
            BsonClassMap.RegisterClassMap<TaxInformationCfop>(cm => cm.MapCreator(c => new TaxInformationCfop(c.Code, c.Description)));
            BsonClassMap.RegisterClassMap<TaxInformationCmp>(cm => cm.MapCreator(c => new TaxInformationCmp(c.Code, c.Description)));
            BsonClassMap.RegisterClassMap<TaxInformationCsosn>(cm => cm.MapCreator(c => new TaxInformationCsosn(c.Code, c.Description)));
            BsonClassMap.RegisterClassMap<TaxInformationCstIcms>(cm => cm.MapCreator(c => new TaxInformationCstIcms(c.Code, c.Description)));
            BsonClassMap.RegisterClassMap<TaxInformationCstPisCofins>(cm => cm.MapCreator(c => new TaxInformationCstPisCofins(c.Code, c.Description)));
            BsonClassMap.RegisterClassMap<TaxInformationNcm>(cm => cm.MapCreator(c => new TaxInformationNcm(c.Code, c.Description, c.CestList)));
            BsonClassMap.RegisterClassMap<TaxInformationOrigin>(cm => cm.MapCreator(c => new TaxInformationOrigin(c.Code, c.Description)));
            BsonClassMap.RegisterClassMap<TaxInformationTaxRateIcms>();
        }
    }
}
