using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class CashClosingCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public Guid CashId { get; set; }

        public CashClosingCommandResult()
        {

        }

        public CashClosingCommandResult(Guid id, Guid cashId)
        {
            Id = id;
            CashId = cashId;
        }

        public CashClosingCommandResult(Guid id)
        {
            Id = id;
        }
    }
}
