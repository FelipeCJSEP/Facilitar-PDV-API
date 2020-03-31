using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class ProductUnitCommandHandler : ICommand
    {
        public string Initials { get; set; }
        public string Description { get; set; }
        public bool Fracionable { get; set; }
    }
}
