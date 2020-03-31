using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using FacilitarPDV.Domain.ValueObjects;

namespace FacilitarPDV.Domain.Entities
{
    public class Product : Entity
    {
        public string ReferenceCode { get; private set; }
        public string Name { get; private set; }
        public string BarCode { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal MinQuantity { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal SalePrice { get; private set; }
        public ProductUnit BuyingUnit { get; private set; }
        public ProductUnit SellingUnit { get; private set; }
        public ValueObjects.TaxInformation TaxInformation { get; private set; }
        public string Description { get; private set; }
        public List<Category> Categories { get; private set; }

        public Product(string referenceCode, string name, string barCode, decimal quantity, decimal minQuantity, decimal costPrice, decimal salePrice, ProductUnit buyingUnit, ProductUnit sellingUnit, ValueObjects.TaxInformation taxInformation, string description, List<Category> categories)
        {
            ReferenceCode = referenceCode;
            Name = name;
            BarCode = barCode;
            Quantity = quantity;
            MinQuantity = minQuantity;
            CostPrice = costPrice;
            SalePrice = salePrice;
            BuyingUnit = buyingUnit;
            SellingUnit = sellingUnit;
            TaxInformation = taxInformation;
            Description = description;
            Categories = categories;
        }

        public Product(Guid id, string name, decimal salePrice, ProductUnit sellingUnit, ValueObjects.TaxInformation taxInformation)
        {
            Id = id;
            Name = name;
            SalePrice = salePrice;
            SellingUnit = sellingUnit;
            TaxInformation = taxInformation;
        }
    }
}
