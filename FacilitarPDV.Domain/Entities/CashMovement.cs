using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class CashMovement : Entity
    {
        public decimal Value { get; private set; }
        public DateTime Hour { get; private set; }
        public ECashMovementType Type { get; private set; }
        [BsonIgnoreIfNull]
        public string Remark { get; private set; }
        public Cash Cash { get; private set; }
        public User User { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public CashMovement(decimal value, DateTime hour, ECashMovementType type, string remark, Cash cash, User user, PaymentMethod paymentMethod)
        {
            Value = value;
            Hour = hour;
            Type = type;
            Remark = remark;
            Cash = cash;
            User = user;
            PaymentMethod = paymentMethod;
        }
    }
}
