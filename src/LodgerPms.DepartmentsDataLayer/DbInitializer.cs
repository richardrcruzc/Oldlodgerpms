using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Domain.Departments;
using LodgerPms.Domain.Departments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
