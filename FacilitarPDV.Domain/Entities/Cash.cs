using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace FacilitarPDV.Domain.Entities
{
    public class Cash : Entity
    {
        [BsonIgnoreIfNull]
        public int Number { get; private set; }
        [BsonIgnoreIfNull]
        public ECashStatus Status { get; private set; }
        [BsonIgnoreIfNull]
        public DateTime? Opening { get; private set; }
        [BsonIgnoreIfNull]
        public DateTime? Closing { get; private set; }
        [BsonIgnoreIfNull]
        public string OpeningRemark { get; private set; }
        [BsonIgnoreIfNull]
        public string ClosingRemark { get; private set; }
        [BsonIgnoreIfNull]
        public User OpeningUser { get; private set; }
        [BsonIgnoreIfNull]
        public User ClosingUser { get; private set; }

        public Cash(int number, ECashStatus status, DateTime opening, DateTime closing, string openingRemark, string closingRemark, User openingUser, User closingUser)
        {
            Number = number;
            Status = status;
            Opening = opening;
            Closing = closing;
            OpeningRemark = openingRemark;
            ClosingRemark = closingRemark;
            OpeningUser = openingUser;
            ClosingUser = closingUser;
        }

        public Cash(Guid id, int number, User closingUser)
        {
            Id = id;
            Number = number;
            ClosingUser = closingUser;
        }
    }
}
