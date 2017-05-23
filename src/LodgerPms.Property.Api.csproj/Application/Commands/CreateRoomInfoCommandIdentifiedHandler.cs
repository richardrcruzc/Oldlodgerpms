using LodgerPms.Domain.Rooms;
using LodgerPms.Property.Api.Infrastructure.Commands;
using LodgerPms.Property.Api.Infrastructure.Data;
using LodgerPms.Property.Api.Infrastructure.Idempotency;
using LodgerPms.Property.Api.Infrastructure.Services;
using MediatR;
using System;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.Application.Commands
{
  
    public class CreateRoomInfoCommandIdentifiedHandler : IdentifierCommandHandler<CreateRoomInfoCommand, bool>
    {
        public CreateRoomInfoCommandIdentifiedHandler(IMediator mediator, IRequestManager requestManager) : base(mediator, requestManager)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for creating order.
        }
    }
    public class CreateRoomInfoCommandHandler
      : IAsyncRequestHandler<CreateRoomInfoCommand, bool>
    {
        private readonly PropertyContext _propertyContext;
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CreateRoomInfoCommandHandler(IMediator mediator, PropertyContext propertyContext, IIdentityService identityService)
        {
            _propertyContext = propertyContext ?? throw new ArgumentNullException(nameof(propertyContext));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateRoomInfoCommand message)
        {
            // Add/Update the Buyer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate


            string number = message.RoomInfo.RoomNumber;
            RoomType type = message.RoomInfo.RoomType;
            BedType bedType = message.RoomInfo.BedType;
            RoomLocation location = message.RoomInfo.RoomLocation;

          var room = RoomInfo.Create(number, type, bedType, location);
                                  

            _propertyContext.Add(room);

            return await _propertyContext.SaveEntitiesAsync();
        }
    }
}
