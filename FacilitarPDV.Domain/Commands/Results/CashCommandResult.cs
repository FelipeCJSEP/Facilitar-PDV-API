using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class CashCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public int Number { get; set; }

        public CashCommandResult() { }

        public CashCommandResult(Guid id)
        {
            Id = id;
        }

        public CashCommandResult(Guid id, int number)
        {
            Id = id;
            Number = number;
        }
    }
}
