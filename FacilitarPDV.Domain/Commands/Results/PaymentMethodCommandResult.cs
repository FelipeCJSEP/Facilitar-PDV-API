using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class PaymentMethodCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public PaymentMethodCommandResult() { }

        public PaymentMethodCommandResult(Guid id) => Id = id;

        public PaymentMethodCommandResult(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
