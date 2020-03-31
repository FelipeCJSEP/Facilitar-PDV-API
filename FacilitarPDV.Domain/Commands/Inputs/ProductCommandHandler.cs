using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class ProductCommandHandler : ICommand
    {
        public class ProductUnitInfo
        {
            public Guid Id { get; set; }
            public string Initials { get; set; }
            public bool Fracionable { get; set; }
        }

        public class TaxInformationInfo
        {
            public DateTime LastPriceUpdate { get; private set; }
            public DateTime LastInput { get; private set; }
            public DateTime LastOutput { get; private set; }
            public string OriginCode { get; private set; }
            public string CstIcmsCode { get; private set; }
            public string CsosnCode { get; private set; }
            public string CstPisCode { get; private set; }
            public string CstCofinsCode { get; private set; }
            public string NcmCode { get; private set; }
            public string CestCode { get; private set; }
            public string CfopCode { get; private set; }
            public decimal MunicipalTaxRate { get; private set; }
            public decimal StateTaxRate { get; private set; }
            public decimal NationalTaxRate { get; private set; }
            public decimal InternationalTaxRate { get; private set; }
            public EProductType Type { get; private set; }
        }

        public class CategoryInfo
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public string ReferenceCode { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal MinQuantity { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public ProductUnitInfo BuyingUnit { get; set; }
        public ProductUnitInfo SellingUnit { get; set; }
        public TaxInformationInfo TaxInformation { get; set; }
        public string Description { get; set; }
        public List<CategoryInfo> Categories { get; set; }
    }
}