using lodgerpms.Domain.Common;
using System.Collections.Generic;

namespace LodgerPms.Domain.Rooms
{
    public class RoomInfo : AgregateRoot.RoomInfoState
    {

        public static RoomInfo Create(
            string number, RoomType type, BedType bedType,
            RoomLocation location, RoomExposure exposure)
        {

            var room = new RoomInfo {
                RoomNumber =  number,
                RoomType = type,
                RoomTypeId=type.Id,
                BedType = bedType,
                BedTypeId =bedType.Id,
                RoomLocation = location,
                RoomLocationId=location.Id,
            } ;
            return room;

        }

        public void Update(string number, RoomType type, BedType bedType,
            RoomLocation location, RoomExposure exposure)
        {

                RoomNumber = number;
                RoomType = type;
                RoomTypeId = type.Id;
                BedType = bedType;
                BedTypeId = bedType.Id;
                RoomLocation = location;
                RoomLocationId = location.Id;
        }
        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected RoomInfo()
        {
    }

        #endregion

        public bool CommonArea { get; private set; }
        public bool PseudoRoom { get; private set; }
        public bool CanSmoke { get; private set; }
        public string RoomNumber {
            get { return this.RoomNumber; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The RoomNumber must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The RoomNumber must be 10 characters or less.");
                this.RoomNumber = value;
            }
        }
        public string Description {
            get { return this.Description; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The Description must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The Description must be 100 characters or less.");
                this.Description = value;
            }
        }
        public RoomType RoomType {
            get { return this.RoomType; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomType must be provided.");
                 this.RoomType = value;
            }
        }
        public BedType BedType {
            get { return this.BedType; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The BedType must be provided.");
                this.BedType = value;
            }
        }
        public RoomLocation RoomLocation
        {
            get { return this.RoomLocation; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomLocation must be provided.");
                this.RoomLocation = value;
            }
        }
        public ICollection<RoomExposure> RoomExposureList { get; private set; }

        public RoomInfo AddRoomExposure(ICollection<RoomExposure> items)
        {
            foreach (var item in items)
            {
                RoomExposureList.Add(item);
            }

            return this;
        }

        public ICollection<RoomStatus> RoomStatusList { get; private set; }
        public RoomInfo AddRoomStatus(ICollection<RoomStatus> items)
        {
            foreach (var item in items)
            {
                RoomStatusList.Add(item);
            }

            return this;
        }
        public ICollection<RoomFacility> RoomFacilityList { get; private set; }
        public RoomInfo AddRoomRoomFacility(ICollection<RoomFacility> items)
        {
            foreach (var item in items)
            {
                RoomFacilityList.Add(item);
            }

            return this;
        }
    }


}
