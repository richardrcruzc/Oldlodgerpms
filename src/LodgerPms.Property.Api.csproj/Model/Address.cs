using LodgerPms.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.Model
{
    public class Address
       : ValueObject
    {
        public String Street { get; private set; }

        public String City { get; private set; }

        public String State { get; private set; }

        public String Country { get; private set; }

        public String ZipCode { get; private set; }

        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
