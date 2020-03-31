using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities.TaxInformations
{
    public class TaxInformationTaxRateIcms
    {
        public string OriginState { get; private set; }
        public string DestinationState { get; private set; }
        public decimal TaxRate { get; private set; }
     
        public TaxInformationTaxRateIcms(string originState, string destinationState, decimal taxRate)
        {
            OriginState = originState;
            DestinationState = destinationState;
            TaxRate = taxRate;
        }
    }
}
