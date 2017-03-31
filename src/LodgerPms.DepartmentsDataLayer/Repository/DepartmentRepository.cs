


using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.Domain.Departments.Models;
using System.Linq;

namespace LodgerPms.DepartmentsDataLayer.Repository
{
      public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        #region variable

        #endregion

        #region ctor

        public DepartmentRepository(DepartmentsContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region IRepository MEMBERS


        public  Department  GetByDescription(string description)
        {

            var department = Find(d => d.Description == description).FirstOrDefault();

            return department;

        }


        #endregion
    }

}
