
using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms
{
    public class RoomLocation : Identity
    {
        public static RoomLocation Create(string code, string description)
        {
            var obj = new RoomLocation { Description = description, Code = code };
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
        protected RoomLocation()
        {
        }

        #endregion

        public string Description
        {
            get { return this.Description; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomLocation description  must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The RoomLocation description maximum is 100 characters.");

                this.Description = value;
            }
        }
        public string Code
        {
            get { return this.Code; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomLocation   Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The RoomLocation   Code maximum is 10 characters.");

                this.Code = value;
            }
        }
        public IEnumerable<RoomInfo> RoomInfoList { get; private set; }

    }
}
