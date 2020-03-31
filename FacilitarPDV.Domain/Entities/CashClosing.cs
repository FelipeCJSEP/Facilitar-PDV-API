using FacilitarPDV.Shared.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class CashClosing : Entity
    {
        [BsonIgnoreIfNull]
        public Cash Cash { get; private set; }
        [BsonIgnoreIfNull]
        public PaymentMethod PaymentMethod { get; private set; }
        [BsonIgnoreIfNull]
        public decimal Value { get; private set; }

        public CashClosing(Cash cash, PaymentMethod paymentMethod, decimal value)
        {
            Cash = cash;
            PaymentMethod = paymentMethod;
            Value = value;
        }
    }
}
