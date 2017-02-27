 
namespace  LodgerPms.Domain.CommonData
{
  public class Contact: Identity
  {
    public string CompanyName { get; protected set; }
    public string EmailAddress { get; protected set; }
    public string Phone { get; protected set; }
  }
}