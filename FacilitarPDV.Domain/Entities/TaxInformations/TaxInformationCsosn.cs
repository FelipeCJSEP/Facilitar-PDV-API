using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationCsosn : TaxInformation
    {
        public TaxInformationCsosn(string code, string description) : base(code, description) { }

        public TaxInformationCsosn(string code) : base(code) { }
    }
}
