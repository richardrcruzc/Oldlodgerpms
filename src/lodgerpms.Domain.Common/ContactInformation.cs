
using static lodgerpms.Domain.Common.Enums;

namespace lodgerpms.Domain.Common
{
    public class ContactInformation : AgregateRoot.ContactInformationState
    {
        public ContactInformation(
                ContactType contactType,
                EmailAddress emailAddress,
                PostalAddress postalAddress,
                Telephone primaryTelephone,
                Telephone secondaryTelephone)
        {
            this.ContactType = contactType;
            this.EmailAddress = emailAddress;
            this.PostalAddress = postalAddress;
            this.PrimaryTelephone = primaryTelephone;
            this.SecondaryTelephone = secondaryTelephone;
        }

        public ContactInformation(ContactInformation contactInformation)
            : this(contactInformation.ContactType,
                  contactInformation.EmailAddress,
                   contactInformation.PostalAddress,
                   contactInformation.PrimaryTelephone,
                   contactInformation.SecondaryTelephone)
        {
        }

        public void Update(string id ) {

        }
        internal ContactInformation()
        {
        }

        public ContactType ContactType { get; private set; }
        public EmailAddress EmailAddress { get; private set; }

        public PostalAddress PostalAddress { get; private set; }

        public Telephone PrimaryTelephone { get; private set; }

        public Telephone SecondaryTelephone { get; private set; }

        public ContactInformation ChangeEmailAddress(EmailAddress emailAddress)
        {
            return new ContactInformation(
                this.ContactType,
                    emailAddress,
                    this.PostalAddress,
                    this.PrimaryTelephone,
                    this.SecondaryTelephone);
        }

        public ContactInformation ChangePostalAddress(PostalAddress postalAddress)
        {
            return new ContactInformation(
                this.ContactType,
                   this.EmailAddress,
                   postalAddress,
                   this.PrimaryTelephone,
                   this.SecondaryTelephone);
        }

        public ContactInformation ChangePrimaryTelephone(Telephone telephone)
        {
            return new ContactInformation(
                this.ContactType,
                   this.EmailAddress,
                   this.PostalAddress,
                   telephone,
                   this.SecondaryTelephone);
        }

        public ContactInformation ChangeSecondaryTelephone(Telephone telephone)
        {
            return new ContactInformation(
                this.ContactType,
                   this.EmailAddress,
                   this.PostalAddress,
                   this.PrimaryTelephone,
                   telephone);
        }

        public override string ToString()
        {
            return "ContactInformation [ContactType ="+ ContactType
                    + ", emailAddress=" + EmailAddress
                    + ", postalAddress=" + PostalAddress
                    + ", primaryTelephone=" + PrimaryTelephone
                    + ", secondaryTelephone=" + SecondaryTelephone + "]";
        }

        //protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        //{
        //    yield return this.EmailAddress;
        //    yield return this.PostalAddress;
        //    yield return this.PrimaryTelephone;
        //    yield return this.SecondaryTelephone;
        //}
    }
}
