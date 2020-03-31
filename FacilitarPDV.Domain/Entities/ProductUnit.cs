using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class ProductUnit : Entity
    {
        public string Initials { get; private set; }
        public string Description { get; private set; }
        public bool Fracionable { get; private set; }

        public ProductUnit(string initials, string description, bool fracionable)
        {
            Initials = initials;
            Description = description;
            Fracionable = fracionable;
        }

        public ProductUnit(Guid id, string initials, bool fracionable)
        {
            Id = id;
            Initials = initials;
            Fracionable = fracionable;
        }
    }
}
