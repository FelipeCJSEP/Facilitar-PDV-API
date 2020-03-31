using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacilitarPDV.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FacilitarPDV.Domain.Commands.Inputs;
using FacilitarPDV.Domain.Commands.Handlers;
using FacilitarPDV.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using FacilitarPDV.Domain.Repositories;
using FacilitarPDV.Domain.Enumerators;

namespace FacilitarPDV.Api.Controllers

{
    public class CashController : BaseController
    {
        private readonly CashHandler _handler;
        private readonly ICashRepository _repository;
        public CashController(CashHandler handler, ICashRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/cash")]
        public IActionResult Get() => Ok(_repository.Get());

        [HttpGet]
        [Route("v1/cash/{id}")]
        public IActionResult Get(Guid id) => Ok(_repository.Get(id));

        [HttpGet]
        [Route("v1/cash/{initialDate}/{finalDate}")]
        public IActionResult Get(DateTime initialDate, DateTime finalDate)
        {
            return Ok(_repository.Get(initialDate, finalDate));
        }

        [HttpPost]
        [Route("v1/cash")]

        public async Task<IActionResult> Insert([FromBody]CashCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("v1/cash/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]CashCommandHandler command)
        {
            ICommandResult result = _handler.Handl(id, command);
            return await Response(result, _handler.Notifications);
        }

        [HttpDelete]
        [Route("v1/cash/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ICommandResult result = _handler.Handl(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
