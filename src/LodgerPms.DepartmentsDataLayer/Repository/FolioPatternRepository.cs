


using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.Domain.Departments.Models;
using System.Linq;

namespace LodgerPms.DepartmentsDataLayer.Repository
{
      public class FolioPatternRepository : Repository<FolioPattern>, IFolioPatternRepository
    {
        #region variable

        #endregion

        #region ctor

        public FolioPatternRepository(DepartmentsContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region IRepository MEMBERS


        public FolioPattern GetByDescription(string description)
        {

            var department = Find(d => d.Description == description).FirstOrDefault();

            return department;

        }


        #endregion
    }

}
