using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Results
{
    public class ProductCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string ReferenceCode { get; set; }
        public string Name { get; set; }

        public ProductCommandResult() { }

        public ProductCommandResult(Guid id) => Id = id;

        public ProductCommandResult(Guid id, string referenceCode, string name)
        {
            Id = id;
            ReferenceCode = referenceCode;
            Name = name;
        }
    }
}
