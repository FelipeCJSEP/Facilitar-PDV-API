using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Shared.Entities
{
    public class TaxInformation
    {
        public string Code { get; private set; }
        public string Description { get; private set; }

        public TaxInformation(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public TaxInformation(string code) => Code = code;
    }
}
