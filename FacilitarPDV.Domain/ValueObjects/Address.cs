using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.ValueObjects
{
    public class Address
    {
        public string ZipCode { get; private set; }
        public string PublicPlace { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string State { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }

        public Address(string zipCode, string publicPlace, string number, string complement, string neighborhood, string state, string county, string country)
        {
            ZipCode = zipCode;
            PublicPlace = publicPlace;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            State = state;
            County = county;
            Country = country;
        }
    }
}
