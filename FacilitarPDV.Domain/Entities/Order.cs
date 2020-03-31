using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class Order : Entity
    {
        public string Number { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public string Remark { get; private set; }
        public DateTime? Release { get; private set; }
        public EOrderStatus Status { get; private set; }

        public Order(string number, List<OrderItem> items, string remark, DateTime? release)
        {
            Number = number;
            Items = items;
            Remark = remark;
            Release = release;
            Status = EOrderStatus.Created;
        }
    }
}
