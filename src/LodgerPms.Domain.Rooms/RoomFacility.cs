

using lodgerpms.Domain.Common;
using System.Collections.Generic;

namespace LodgerPms.Domain.Rooms
{
    public class RoomFacility : Identity
    {
        public static RoomFacility Create(string code, string description)
        {

             var obj = new RoomFacility { Description = description, Code = code };
            return obj;

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
        protected RoomFacility()
        {
        }

        #endregion


        private string description;
        public string Description
        {
            get { return description; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The Bed Type description  must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The Bed Type description maximum is 100 characters.");

                description = value;
            }
        }

        private string code;
        public string Code
        {
            get { return code; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The Facility Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The Facility Code maximum is 10 characters.");

                code = value;
            }
        }
        public RoomInfo RoomInfoList { get; private set; }

    }
}
