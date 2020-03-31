using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class OrderCommandHandler : ICommand
    {
        public class TaxInformationInfo
        {
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
        }

        public class ProductUnitInfo
        {
            public Guid Id { get; set; }
            public string Initials { get; set; }
            public bool Fracionable { get; set; }
        }

        public class ProductInfo
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal SalePrice { get; set; }
            public ProductUnitInfo SellingUnit { get; set; }
            public TaxInformationInfo TaxInformation { get; set; }
        }

        public class OrderItemInfo
        {
            public ProductInfo Product { get; set; }
            public decimal Quantity { get; set; }
            public decimal Discount { get; set; }
        }

        public string Number { get; set; }
        public List<OrderItemInfo> Items { get; set; }
        public string Remark { get; set; }
        public DateTime? Release { get; set; }
        public EOrderStatus Status { get; set; }
    }
}
