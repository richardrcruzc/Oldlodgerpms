


using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.Domain.Departments.Models;
using System.Linq;

namespace LodgerPms.DepartmentsDataLayer.Repository
{
      public class DepartmentGroupRepository : Repository<DepartmentGroup>, IDepartmentGroupRepository
    {
        #region variable

        #endregion

        #region ctor

        public DepartmentGroupRepository(DepartmentsContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region IRepository MEMBERS


        public  DepartmentGroup  GetByDescription(string description)
        {

            var department = Find(d => d.Description == description).FirstOrDefault();

            return department;

        }


        #endregion
    }

}
