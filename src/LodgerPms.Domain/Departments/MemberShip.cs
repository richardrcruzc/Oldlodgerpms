using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments
{
    public class MemberShip
    {
        public  MemberShip()
        {
        }
        public string Guest { get; private set; }
        public string Arrival { get; private set; }
        public string Departure { get; private set; }
        public string MemeberType { get; private set; }
        public string Level { get; private set; }
        public string MemberNumber { get; private set; }
    }
}
