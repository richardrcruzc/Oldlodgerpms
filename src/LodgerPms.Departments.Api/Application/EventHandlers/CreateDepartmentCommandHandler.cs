using LodgerPms.Departments.Api.Application.Commands;
using LodgerPms.Departments.Api.Application.Commands.Departments; 
using LodgerPms.Departments.Api.Infrastructure.Idempotency;
using LodgerPms.Departments.Api.Infrastructure.Services;
using LodgerPms.Departments.Api.Model;
using LodgerPms.Departments.Api.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Application.EventHandlers
{
    public class CreateDepartmentCommandIdentifiedHandler : IdentifierCommandHandler<CreateDepartmentCommand, bool>
    {
        public CreateDepartmentCommandIdentifiedHandler(IMediator mediator, IRequestManager requestManager) : base(mediator, requestManager)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for creating order.
        }
    }

    public class CreateDepartmentCommandHandler
        : IAsyncRequestHandler<CreateDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _deptoRepository;
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CreateDepartmentCommandHandler(IMediator mediator, IDepartmentRepository deptoRepository, IIdentityService identityService)
        {
            _deptoRepository = deptoRepository ?? throw new ArgumentNullException(nameof(deptoRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateDepartmentCommand message)
        {
            // Add/Update the Buyer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate
            var group = DepartmentGroup.Create(message.DepartmentGroup.Id, message.DepartmentGroup.Description);
            var depto = Department.Create(message.Id, group, message.DepartmentType, message.Description, message.ApplyTax, message.Amount, message.Percentage);
            
            _deptoRepository.Add(depto);

            return await _deptoRepository.UnitOfWork
                .SaveEntitiesAsync();
        }
    }
}
