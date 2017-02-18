
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms
{
    public class RoomGroup : Identity
    {
        public static RoomGroup Create(string code, string description)
        {

            var bedType = new RoomGroup { Description = description, Code = code };
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
        protected RoomGroup()
        {
        }

        #endregion



        public string Description
        {
            get { return this.Description; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomGroup description  must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The RoomGroup description maximum is 100 characters.");

                this.Description = value;
            }
        }
        public string Code
        {
            get { return this.Code; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomGroup Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The RoomGroup  Code maximum is 10 characters.");

                this.Code = value;
            }
        }
        public IEnumerable<RoomType> RoomTypeList { get; private set; }

    }
}
