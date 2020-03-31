using FacilitarPDV.Shared.Validations;
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace FacilitarPDV.Shared.Entities
{
    public class Entity : Validation
    {
        [BsonId]
        public Guid Id { get; set; }

        public Entity() => Id = Guid.NewGuid();
    }
}
