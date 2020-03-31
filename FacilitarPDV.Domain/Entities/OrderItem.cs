using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class OrderItem
    {
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Discount { get; private set; }

        public OrderItem(Product product, decimal quantity, decimal discount)
        {
            Product = product;
            Quantity = quantity;
            Discount = discount;
        }
    }
}
