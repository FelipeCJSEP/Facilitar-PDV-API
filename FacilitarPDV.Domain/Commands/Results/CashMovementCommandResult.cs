using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class CashMovementCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public Guid CashId { get; set; }

        public CashMovementCommandResult() { }

        public CashMovementCommandResult(Guid id) => Id = id;

        public CashMovementCommandResult(Guid id, Guid cashId)
        {
            Id = id;
            CashId = cashId;
        }
    }
}
