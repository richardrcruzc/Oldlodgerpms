using lodgerpms.Domain.Common;
using LodgerPms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms
{
    public class BedType : Identity
    {
        public static BedType Create(string code, string description)
        {
            AssertionConcern.AssertArgumentNotNull(description, "The Bed Type description must be provided.");
            AssertionConcern.AssertArgumentLength(description, 100, "The Bed Type description maximum is 100 characters.");

            AssertionConcern.AssertArgumentNotNull(code, "The Bed Type Code must be provided.");
            AssertionConcern.AssertArgumentLength(code, 10, "The Bed Type Code maximum is 10 characters.");


            var bedType = new BedType { Description = description , Code=code};
            return bedType;

        }

        public void Update(string code, string description)
        {
            this.Description = description;
            this.Code = code;
        }

        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected BedType()
        {
        }

        #endregion


        public string Description { get; private set; }
        public string Code { get; private set; }

        public IEnumerable<RoomInfo> RoomInfoList { get; private set; }

    }
}
