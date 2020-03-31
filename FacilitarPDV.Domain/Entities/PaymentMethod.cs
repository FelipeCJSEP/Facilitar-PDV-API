using FacilitarPDV.Shared.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class PaymentMethod : Entity
    {
        public string Description { get; private set; }
        public string Cmp { get; private set; }
        [BsonIgnoreIfNull]
        public bool? Active { get; private set; }

        public PaymentMethod(string description, string cmp)
        {
            Description = description;
            Cmp = cmp;
            Active = true;
        }

        public PaymentMethod(string description, string cmp, bool? active)
        {
            Description = description;
            Cmp = cmp;
            Active = active;
        }

        public PaymentMethod(Guid id, string description, string cmp)
        {
            Id = id;
            Description = description;
            Cmp = cmp;
        }
    }
}
