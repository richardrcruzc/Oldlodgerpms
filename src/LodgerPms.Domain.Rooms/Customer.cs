using lodgerpms.Domain.Common;
 
namespace LodgerPms.Domain.Rooms
{
    public class Department: Contact
    {
        public Department(string firstName, string lastName, string email)
        {
            FullName = new FullName(firstName, lastName);
            EmailAddress = email;
           
        }
        internal Department()
        {
        }
        public string Code
        {
            get { return this.Code; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The Bed Type Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The Bed Type Code maximum is 10 characters.");

                this.Code = value;
            }
        }
        public string SalesPersonId { get; private set; }

    }
}
