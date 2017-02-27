using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms
{
    public class Status : Identity
    {
        public static Status Create(string description, string code)
        {
             var status = new Status { Description=description , Code = code };
            return status;

        }
        public void Update(string description, string code)
        {
            Description = description; Code = code ;


        }
        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected Status()
        {
        }

        #endregion

        public string Description {
            get { return this.Description; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The Description must be provided.");
                this.Description = value;
            }
        }
        public string Code {
            get { return this.Code; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The Code must be provided.");
                this.Code = value;
            }
        }

        public IEnumerable<RoomStatus> RoomStatusList { get; private set; }

    }
}
