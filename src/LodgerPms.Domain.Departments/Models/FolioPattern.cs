using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Models
{
    public class FolioPattern : Identity
    {
        public static FolioPattern Create(string description)
        {
            AssertionConcern.AssertArgumentNotNull(description, "The Folio Pattern description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 100, "The Folio Pattern description maximum is 100 characters.");
            var obj = new FolioPattern { Description = description };
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


        public string Description { get; private set; }


    }
}
