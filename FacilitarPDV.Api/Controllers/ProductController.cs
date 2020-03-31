using FacilitarPDV.Domain.Commands.Handlers;
using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacilitarPDV.Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ProductHandler _handler;
        private readonly IProductRepository _repository;

        public ProductController(ProductHandler handler, IProductRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/product")]
        public IActionResult Get() => Ok(_repository.Get());

        [HttpGet]
        [Route("v1/product/{id}")]
        public IActionResult Get(Guid id) => Ok(_repository.Get(id));

        [HttpPost]
        [Route("v1/product")]
        public async Task<IActionResult> Insert([FromBody]ProductCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("v1/product/{id}")]
        public async Task<IActionResult> Insert(Guid id, [FromBody]ProductCommandHandler command)
        {
            ICommandResult result = _handler.Handl(id, command);
            return await Response(result, _handler.Notifications);
        }

        [HttpDelete]
        [Route("v1/product/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ICommandResult result = _handler.Handl(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
