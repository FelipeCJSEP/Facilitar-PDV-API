using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationNcm : TaxInformation
    {
        public List<TaxInformationCest> CestList { get; private set; }
        public TaxInformationNcm(string code, string description, List<TaxInformationCest> cestList) :
            base(code, description)
        {
            CestList = cestList;
        }

        public TaxInformationNcm(string code) : base(code) { }
    }
}
