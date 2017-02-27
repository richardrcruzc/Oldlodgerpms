using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Bookings
{

    public class EntryPoint : Identity
    {
        public static EntryPoint Create(string description)
        {
            AssertionConcern.AssertArgumentNotNull(description, "The Entry Point description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 100, "The Entry Point description maximum is 100 characters.");
            var obj = new EntryPoint { Description = description };
            return obj;
        }
        #region Added to please the O/RM
        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected EntryPoint()
        {
        }

        #endregion


        public string Description { get; private set; }


    }
}
