using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationCmp : TaxInformation
    {
        public TaxInformationCmp(string code, string description) : base(code, description)
        {
        }
    }
}
