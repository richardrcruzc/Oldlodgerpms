using LodgerPms.DepartmentsDataLayer.Context;
using System.Linq;

namespace LodgerPms.DepartmentsDataLayer
{
    public class DbInitializer
    {
        public static void Initialize(DepartmentsContext cntxt)
        {
            if (!cntxt.Departments.Any())
            {
                //var d =Department.Create("Department");
               // cntxt.Departments.AddAsync(d);

            }
        }
    }

}
