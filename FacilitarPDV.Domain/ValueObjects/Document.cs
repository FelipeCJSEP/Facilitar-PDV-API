using System;
using System.Collections.Generic;
using System.Text;
using FacilitarPDV.Domain.Enumerators;

namespace FacilitarPDV.Domain.ValueObjects
{
    public class Document
    {
        public string Value { get; private set; }
        public EDocumentType Type { get; private set; }

        public Document(string value, EDocumentType type)
        {
            Value = value;
            Type = type;
        }
    }
}
