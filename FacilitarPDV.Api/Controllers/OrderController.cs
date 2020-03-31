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
    public class OrderController : BaseController
    {
        private readonly OrderHandler _handler;
        private readonly IOrderRepository _repository;

        public OrderController(OrderHandler handler, IOrderRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/order")]
        public IActionResult Get() => Ok(_repository.Get());

        [HttpGet]
        [Route("v1/order/{id}")]
        public IActionResult Get(Guid id) => Ok(_repository.Get(id));

        [HttpPost]
        [Route("v1/order")]
        public async Task<IActionResult> Insert([FromBody]OrderCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("v1/order/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]OrderCommandHandler command)
        {
            ICommandResult result = _handler.Handl(id, command);
            return await Response(result, _handler.Notifications);
        }

        [HttpDelete]
        [Route("v1/order/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ICommandResult result = _handler.Handl(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
