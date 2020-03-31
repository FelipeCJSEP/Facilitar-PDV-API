using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class SalePayment : Entity
    {
        public Sale Sale { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public decimal Value { get; private set; }

        public SalePayment(Sale sale, PaymentMethod paymentMethod, decimal value)
        {
            Sale = sale;
            PaymentMethod = paymentMethod;
            Value = value;
        }
    }
}
