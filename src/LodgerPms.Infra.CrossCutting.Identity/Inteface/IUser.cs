
using System.Collections.Generic;
using System.Security.Claims;

namespace LodgerPms.Infra.CrossCutting.Identity.Inteface
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
