using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationCstIcms : TaxInformation
    {
        public TaxInformationCstIcms(string code, string description) : base(code, description) { }

        public TaxInformationCstIcms(string code) : base(code) { }
    }
}
