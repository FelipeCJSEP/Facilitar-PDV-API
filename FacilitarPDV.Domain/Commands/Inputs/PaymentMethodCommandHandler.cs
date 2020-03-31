using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class PaymentMethodCommandHandler : ICommand
    {
        public string Description { get; set; }
        public string Cmp { get; set; }
        public bool? Active { get; set; }
    }
}
