using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Shared
{
    public class NullContactInformation: ContactInformation
    {
        public static NullContactInformation Instance = new NullContactInformation();
    }


}
