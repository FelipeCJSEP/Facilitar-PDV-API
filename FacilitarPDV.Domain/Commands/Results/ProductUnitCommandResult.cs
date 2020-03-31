using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class ProductUnitCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Initials { get; set; }

        public ProductUnitCommandResult() { }

        public ProductUnitCommandResult(Guid id) => Id = id;

        public ProductUnitCommandResult(Guid id, string initials)
        {
            Id = id;
            Initials = initials;
        }
    }
}
