using System.Linq;
using LodgerPms.Domain.SeedWork;
using LodgerPms.Domain.Utilities;
using LodgerPms.Property.Api.Events;
using LodgerPms.Property.Api.Model;
using System.Collections.Generic;

namespace LodgerPms.Domain.Rooms
{
    public class RoomInfo
      : Entity, IAggregateRoot
    {

        public static RoomInfo Create(
            string number, RoomType type, BedType bedType,
            RoomLocation location)
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

            // Add the AddRoomInfoAddedDomainEvent to the domain events collection 
            // to be raised/dispatched when comitting changes into the Database [ After DbContext.SaveChanges() ]            
            room.AddRoomInfoAddedDomainEvent(); 
            
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
            _roomFacilityList = new List<RoomFacility>();
            _roomStatusList = new List<RoomStatus>();
            _roomExposureList = new List<RoomExposure>();
            _roomPictures = new List<Picture>();
        }

        #endregion

        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method OrderAggrergateRoot.AddOrderItem() which includes behaviour.
        private readonly List<Picture> _roomPictures;

        public IEnumerable<Picture> RoomPictures => _roomPictures.AsReadOnly();
        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 





        public string RoomTypeId { get; protected set; }
        public string BedTypeId { get; protected set; }
        public string RoomLocationId { get; protected set; }

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



        private readonly List<RoomExposure> _roomExposureList;

        public IEnumerable<RoomExposure> RoomExposureList => _roomExposureList.AsReadOnly();
         
        public RoomInfo AddRoomExposure(ICollection<RoomExposure> items)
        {
            foreach (var item in items)
            {
                if (_roomExposureList.Where(s => s.Id == item.Id).SingleOrDefault() == null)
                    _roomExposureList.Add(item);
            }

            return this;
        }


        private readonly List<RoomStatus> _roomStatusList;

        public IEnumerable<RoomStatus> RoomStatusList => _roomStatusList.AsReadOnly();
         
        public RoomInfo AddRoomStatus(ICollection<RoomStatus> items)
        {
            foreach (var item in items)
            {
               if( _roomStatusList.Where(s => s.Id == item.Id).SingleOrDefault()==null)
                _roomStatusList.Add(item);
            }

            return this;
        }


        private readonly List<RoomFacility> _roomFacilityList;

        public IEnumerable<RoomFacility> RoomFacilityList => _roomFacilityList.AsReadOnly();
         
        public RoomInfo AddRoomRoomFacility(ICollection<RoomFacility> items)
        {
            foreach (var item in items)
            {
                if (_roomFacilityList.Where(s => s.Id == item.Id).SingleOrDefault() == null)
                    _roomFacilityList.Add(item);
            }

            return this;
        }
         
        internal void AddRoomInfoAddedDomainEvent()
        {
            var orderStartedDomainEvent = new RoomInfoAddedDomainEvent(this);

            this.AddDomainEvent(orderStartedDomainEvent);
        }
    }


}
