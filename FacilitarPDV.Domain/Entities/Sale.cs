using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class Sale : Entity
    {
        public decimal Value { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Change { get; private set; }
        public DateTime? Hour { get; private set; }
        public Cash Cash { get; private set; }
        public User User { get; private set; }
        public Customer Customer { get; private set; }
        public string Xml { get; private set; }
        public bool? Canceled { get; private set; }
        public EEmissionType EmissionType { get; private set; }
    }
}
