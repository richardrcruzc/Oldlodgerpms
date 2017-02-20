using static LodgerPms.Domain.Shared.Enums;

namespace LodgerPms.Domain.Shared
{
    public class EmailAddress : AgregateRoot.EmailAddressState
    {

        public static EmailAddress New(EmailType type, string address, bool mailingList)
        {
            var obj = new EmailAddress {
                EmailType=type,
                Address = address,
                MailingList = mailingList, 
            };
            return obj;
        }

        public void Update(EmailType type, string address, bool mailingList)
        {
            //this.Id = id;
            this.EmailType = type;
            this.Address = address;
            this.MailingList = mailingList; 
        }
        public EmailType EmailType { get; private set; }

        protected EmailAddress() { }

        string address;

        public bool MailingList { get; private set; }
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The email address is required.");
                AssertionConcern.AssertArgumentLength(value, 1, 100, "Email address must be 100 characters or less.");
                AssertionConcern.AssertArgumentMatches(
                        "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",
                        value,
                        "Email address format is invalid.");

                this.address = value;
            }
        }

        public override string ToString()
        {
            return "EmailAddress [address=" + Address + "]";
        }

        //protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        //{
        //    yield return address.ToUpper();
        //}
    }
}
