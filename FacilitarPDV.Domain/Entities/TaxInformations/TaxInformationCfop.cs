using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationCfop : TaxInformation
    {
        public TaxInformationCfop(string code, string description) : base(code, description) { }

        public TaxInformationCfop(string code) : base(code) { }
    }
}
