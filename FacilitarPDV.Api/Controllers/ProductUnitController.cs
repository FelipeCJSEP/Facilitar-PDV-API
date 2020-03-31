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
    public class ProductUnitController : BaseController
    {
        private readonly IProductUnitRepository _repository;
        private readonly ProductUnitHandler _handler;

        public ProductUnitController(IProductUnitRepository repository, ProductUnitHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/product_unit")]
        public IActionResult Get() => Ok(_repository.Get());

        [HttpGet]
        [Route("v1/product_unit/{id}")]
        public IActionResult Get(Guid id) => Ok(_repository.Get(id));

        [HttpPost]
        [Route("v1/product_unit")]
        public async Task<IActionResult> Insert([FromBody]ProductUnitCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("v1/product_unit/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]ProductUnitCommandHandler command)
        {
            ICommandResult result = _handler.Handl(id, command);
            return await Response(result, _handler.Notifications);
        }

        [HttpDelete]
        [Route("v1/product_unit/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ICommandResult result = _handler.Handl(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
