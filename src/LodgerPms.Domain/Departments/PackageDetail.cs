using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments
{
    public class PackageDetail : Identity
    {
        public  PackageDetail()
        {
        }

        public Package Package { get; private set; }
        public string SeasonCode { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal Price { get; private set; }
        public decimal Allowance { get; private set; }
    }
}
