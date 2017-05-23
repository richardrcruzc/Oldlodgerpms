
using LodgerPms.Domain.SeedWork;
using LodgerPms.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms
{
    public class RoomLocation
      : Entity 
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

        private string description;
        public string Description
        {
            get { return description; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomLocation description  must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The RoomLocation description maximum is 100 characters.");

                description = value;
            }
        }
        private string code;
        public string Code
        {
            get { return code; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomLocation   Code must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The RoomLocation   Code maximum is 10 characters.");

                code = value;
            }
        }
        public IEnumerable<RoomInfo> RoomInfoList { get; private set; }

    }
}
