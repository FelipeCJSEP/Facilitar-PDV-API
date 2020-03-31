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
    public class CategoryController : BaseController
    {
        private readonly CategoryHandler _handler;
        private readonly ICategoryRepository _repository;

        public CategoryController(CategoryHandler handler, ICategoryRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/category")]
        public IActionResult Get() => Ok(_repository.Get());

        [HttpGet]
        [Route("v1/category/{id}")]
        public IActionResult Get(Guid id) => Ok(_repository.Get(id));

        [HttpPost]
        [Route("v1/category")]
        public async Task<IActionResult> Insert([FromBody]CategoryCommandHandler command)
        {
            ICommandResult result = _handler.Handl(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("v1/category/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]CategoryCommandHandler command)
        {
            ICommandResult result = _handler.Handl(id, command);
            return await Response(result, _handler.Notifications);
        }

        [HttpDelete]
        [Route("v1/category/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ICommandResult result = _handler.Handl(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
