using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationCest : TaxInformation
    {
        public TaxInformationCest(string code, string description) : base(code, description) { }

        public TaxInformationCest(string code) : base(code) { }
    }
}
