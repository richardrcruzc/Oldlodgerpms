using LodgerPms.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments
{

    public class DepartmentGroup : Identity
    {
        public static DepartmentGroup Create(string description)
        {
            AssertionConcern.AssertArgumentNotNull(description, "The Department Group description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 100, "The Department Group description maximum is 100 characters.");
            var obj = new DepartmentGroup { Description = description };
            return obj;
        }
        #region Added to please the O/RM
        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected DepartmentGroup()
        {
        }

        #endregion


        public Money Currency { get; private set; }
        public string Description { get; private set; }


    }

}
