using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationOrigin : TaxInformation
    {
        public TaxInformationOrigin(string code, string description) : base(code, description) { }

        public TaxInformationOrigin(string code) : base(code) { }
    }
}
