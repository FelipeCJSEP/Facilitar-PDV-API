using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class OrderCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Number { get; set; }

        public OrderCommandResult() { }

        public OrderCommandResult(Guid id) => Id = id;

        public OrderCommandResult(Guid id, string number)
        {
            Id = id;
            Number = number;
        }
    }
}
