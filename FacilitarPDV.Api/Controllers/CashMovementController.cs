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
    public class CashMovementController : BaseController
    {
        private readonly CashMovementHandler _handler;
        private readonly ICashMovementRepository _repository;

        public CashMovementController(CashMovementHandler handler, ICashMovementRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/cash_movement")]
        public IActionResult Get() => Ok(_repository.Get());

        [HttpGet]
        [Route("v1/cash_movement/{id}")]
        public IActionResult Get(Guid id) => Ok(_repository.Get(id));

        [HttpGet]
        [Route("v1/cash_movement/cash/{cashId}")]
        public IActionResult GetByCashId(Guid cashId) => Ok(_repository.GetByCashId(cashId));

        [HttpPost]
        [Route("v1/cash_movement")]
        public async Task<IActionResult> Insert([FromBody]CashMovementCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("v1/cash_movement/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]CashMovementCommandHandler command)
        {
            ICommandResult result = _handler.Handl(id, command);
            return await Response(result, _handler.Notifications);
        }

        [HttpDelete]
        [Route("v1/cash_movement/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ICommandResult result = _handler.Handl(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
