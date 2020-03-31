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
    public class PaymentMethodController : BaseController
    {
        private readonly PaymentMethodHandler _handler;
        private readonly IPaymentMethodRepository _repository;

        public PaymentMethodController(PaymentMethodHandler handler, IPaymentMethodRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/payment_method")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpGet]
        [Route("v1/payment_method/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPost]
        [Route("v1/payment_method")]
        public async Task<IActionResult> Insert([FromBody]PaymentMethodCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("v1/payment_method/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]PaymentMethodCommandHandler command)
        {
            ICommandResult result = _handler.Handl(id, command);
            return await Response(result, _handler.Notifications);
        }

        [HttpDelete]
        [Route("v1/payment_method/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ICommandResult result = _handler.Handl(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
