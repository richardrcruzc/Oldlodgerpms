using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Models
{

    public class DepartmentGroup : Identity
    {
        public static DepartmentGroup Create(string code,  string description)
        {
            AssertionConcern.AssertArgumentNotNull(description, "The Department Group description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 100, "The Department Group description maximum is 100 characters.");
            var obj = new DepartmentGroup { Code=code, Description = description };
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

        private string description;
        public string Description
        {
            get { return description; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "TheDepartment Group description  must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The DepartmentGroup description maximum is 100 characters.");

                description = value;
            }
        }

        private string code;
        public string Code
        {
            get { return code; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The Department Group Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The Department Group Code maximum is 10 characters.");

                code = value;
            }
        }



    }

}
