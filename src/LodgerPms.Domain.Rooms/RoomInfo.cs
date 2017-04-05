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
            RoomFacilityList = new List<RoomFacility>();
            RoomStatusList = new List<RoomStatus>();
            RoomExposureList = new List<RoomExposure>();
    }

        #endregion

        public bool CommonArea { get; private set; }
        public bool PseudoRoom { get; private set; }
        public bool CanSmoke { get; private set; }

        private string roomNumber;
        public string RoomNumber {
            get { return roomNumber; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The RoomNumber must be provided.");
                AssertionConcern.AssertArgumentLength(value, 10, "The RoomNumber must be 10 characters or less.");
                roomNumber = value;
            }
        }
        private string description;
        public string Description {
            get { return description; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The Description must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The Description must be 100 characters or less.");
                description = value;
            }
        }
        private RoomType roomType;
        public RoomType RoomType {
            get { return roomType; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomType must be provided.");
                roomType = value;
            }
        }
        private BedType bedType;
        public BedType BedType {
            get { return bedType; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The BedType must be provided.");
                bedType = value;
            }
        }

        private RoomLocation roomLocation;
        public RoomLocation RoomLocation
        {
            get { return roomLocation; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The RoomLocation must be provided.");
                roomLocation = value;
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
