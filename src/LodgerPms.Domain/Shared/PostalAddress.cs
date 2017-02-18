using System;

namespace LodgerPms.Domain.Shared
{
    public class PostalAddress: AgregateRoot.PostalAddressState
    {
        public PostalAddress(
                String streetAddress,
                 String streetAddress2,
                String city,
                String stateProvince,
                String postalCode,
                String countryCode)
        {
            this.City = city;
            this.CountryCode = countryCode;
            this.PostalCode = postalCode;
            this.StateProvince = stateProvince;
            this.StreetAddress = streetAddress;
            this.StreetAddress2 = streetAddress2;
        }

        public PostalAddress(PostalAddress postalAddress)
            : this(postalAddress.StreetAddress,
                  postalAddress.StreetAddress2,
                   postalAddress.City,
                   postalAddress.StateProvince,
                   postalAddress.PostalCode,
                   postalAddress.CountryCode)
        {
        }

        protected PostalAddress() { }

        public string City {
            get { return this.City; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The City must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The City must be 200 characters or less.");
                this.City = value;
            }
        }

        public string CountryCode {
            get { return this.CountryCode; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The Country Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The Country Code must be 10 characters or less.");
                this.CountryCode = value;
            }
        }

        public string PostalCode {
            get { return this.PostalCode; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The Postal Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The Postal Code must be 10 characters or less.");
                this.PostalCode = value;
            }
        }

        public string StateProvince { get; private set; }

        public string StreetAddress {
            get { return this.StreetAddress; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The Street Address must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The Street Address must be 100 characters or less.");
                this.StreetAddress = value;
            }
        }
        public string StreetAddress2 { get; private set; }

        public override string ToString()
        {
            return "PostalAddress [streetAddress=" + StreetAddress
                    + ", streetAddress2 = " + StreetAddress == null?"":StreetAddress
                    + ", city=" + City + ", stateProvince=" + StateProvince
                    + ", postalCode=" + PostalCode
                    + ", countryCode=" + CountryCode + "]";
        }


    }
}
