using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class CategoryCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CategoryCommandResult() { }

        public CategoryCommandResult(Guid id) => Id = id;

        public CategoryCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
