using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class CustomerCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CustomerCommandResult() {}

        public CustomerCommandResult(Guid id) => Id = id;

        public CustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
