using FacilitarPDV.Domain.ValueObjects;
using FacilitarPDV.Shared.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class Customer : Entity
    {
        [BsonIgnoreIfNull]
        public Document PrincipalDocument { get; private set; }
        [BsonIgnoreIfNull]
        public Document SecundaryDocument { get; private set; }
        [BsonIgnoreIfNull]
        public Name Name { get; private set; }
        [BsonIgnoreIfNull]
        public Address Address { get; private set; }
        [BsonIgnoreIfNull]
        public string Email { get; private set; }
        [BsonIgnoreIfNull]
        public string Remark { get; private set; }

        public Customer(Document principalDocument, Document secundaryDocument, Name name, Address address, string email, string remark)
        {
            PrincipalDocument = principalDocument;
            SecundaryDocument = secundaryDocument;
            Name = name;
            Address = address;
            Email = email;
            Remark = remark;
        }
    }
}
