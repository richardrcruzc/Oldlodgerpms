
using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms
{
    public class RoomType: AgregateRoot.RoomTypeState
    {
        public static RoomType Create(string code, string description, RoomGroup group, int max)
        {

            var obj = new RoomType { Description = description, Code = code , Group =  group, Maximun= max};
            return obj;

        }
        public void Update(string code, string description, RoomGroup group, int max)
        {
            this.Description = description;
            this.Code = code;
            this.Group = group;
            this.Maximun = max;
        }

        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected RoomType()
        {
        }

        #endregion


        private string description;
        public string Description
        {
            get { return description; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomType description  must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The RoomType description maximum is 100 characters.");

                description = value;
            }
        }
        private string code;
        public string Code
        {
            get { return code; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomType Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The RoomType Code maximum is 10 characters.");

               code = value;
            }
        }
        private RoomGroup group;
        public RoomGroup Group {
            get { return group; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The Group must be provided.");
               group = value;
            }
        }
        public int Maximun { get; private set; }
        public IEnumerable<RoomInfo> RoomInfoList { get; private set; }
    }
}
