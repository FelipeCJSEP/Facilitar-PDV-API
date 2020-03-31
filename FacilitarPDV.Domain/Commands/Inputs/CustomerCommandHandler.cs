using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.Commands.Inputs
{
    public class CustomerCommandHandler : ICommand
    {
        public class DocumentInfo
        {
            public string Value { get; set; }
            public EDocumentType Type { get; set; }
        }

        public class NameInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class AddressInfo
        {
            public string ZipCode { get; set; }
            public string PublicPlace { get; set; }
            public string Number { get; set; }
            public string Complement { get; set; }
            public string Neighborhood { get; set; }
            public string State { get; set; }
            public string County { get; set; }
            public string Country { get; set; }
        }

        public DocumentInfo PrincipalDocument { get; set; }
        public DocumentInfo SecundaryDocument { get; set; }
        public NameInfo Name { get; set; }
        public AddressInfo Address { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
    }
}
