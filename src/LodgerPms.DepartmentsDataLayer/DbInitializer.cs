using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Domain.Departments.Models;
using System;
using System.Linq;

namespace LodgerPms.DepartmentsDataLayer
{
    public class DbInitializer
    {
        public static void Initialize(DepartmentsContext cntxt)
        {
            if (!cntxt.DepartmentGroups.Any())
            {
                var dg = DepartmentGroup.Create("Group1");
                cntxt.DepartmentGroups.AddAsync(dg);
            }
                if (!cntxt.Departments.Any())
            {

                var dg = DepartmentGroup.Create("Group1");

                var d = Department.Create(Guid.NewGuid().ToString(), dg, DepartmentType.Debit,"Department 1", false,10, 0);
               cntxt.Departments.AddAsync(d);
                  d = Department.Create(Guid.NewGuid().ToString(), dg, DepartmentType.Debit, "Department 2", false, 10, 0);
                cntxt.Departments.AddAsync(d);

            }
        }
    }

}
