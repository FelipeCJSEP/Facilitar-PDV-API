using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationCstPisCofins : TaxInformation
    {
        public TaxInformationCstPisCofins(string code, string description) : base(code, description) { }

        public TaxInformationCstPisCofins(string code) : base(code) { }
    }
}
