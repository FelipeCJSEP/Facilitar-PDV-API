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
    public class CustomerController : BaseController
    {
        private readonly CustomerHandler _handler;
        private readonly ICustomerRepository _repository;

        public CustomerController(CustomerHandler handler, ICustomerRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/customer")]
        public IActionResult Get() => Ok(_repository.Get());

        [HttpGet]
        [Route("v1/customer/{id}")]
        public IActionResult Get(Guid id) => Ok(_repository.Get(id));

        [HttpPost]
        [Route("v1/customer")]
        public async Task<IActionResult> Insert([FromBody]CustomerCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("v1/customer/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]CustomerCommandHandler command)
        {
            ICommandResult result = _handler.Handl(id, command);
            return await Response(result, _handler.Notifications);
        }

        [HttpDelete]
        [Route("v1/customer/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ICommandResult result = _handler.Handl(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
