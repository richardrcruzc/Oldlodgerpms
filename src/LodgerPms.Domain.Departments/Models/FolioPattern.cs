using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Models
{
    public class FolioPattern : Identity
    {
        public static FolioPattern Create(string code,string description)
        {           
            var obj = new FolioPattern { Code=code,Description = description };
            return obj;
        }
        #region Added to please the O/RM
        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected FolioPattern()
        {
        }

        #endregion

        private string code;
        public string Code {
            get { return code; }
            private set {
                AssertionConcern.AssertArgumentNotNull(value, "The Folio Pattern code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 5, "The Folio Pattern code maximum is 5 characters.");
                code = value;
            }
        }
        private string description;
        public string Description {
            get { return description; }
            private set {

                AssertionConcern.AssertArgumentNotNull(value, "The Folio Pattern description must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The Folio Pattern description maximum is 100 characters.");
                description = value;

            } }


    }
}
