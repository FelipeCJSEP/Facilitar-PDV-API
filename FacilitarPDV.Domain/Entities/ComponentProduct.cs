using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class ComponentProduct
    {
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
    }
}
