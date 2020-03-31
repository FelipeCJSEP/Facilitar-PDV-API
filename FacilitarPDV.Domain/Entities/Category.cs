using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public Category ParentCategory { get; private set; }
        public bool? Active { get; private set; }

        public Category(string name, Category parentCategory)
        {
            Name = name;
            ParentCategory = parentCategory;
            Active = true;
        }

        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
