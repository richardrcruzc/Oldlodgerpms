

using LodgerPms.Domain.Core.Bus;
using LodgerPms.Domain.Core.Events;
using LodgerPms.Domain.Core.Notifications;
using LodgerPms.Domain.Departments.Commands;
using LodgerPms.Domain.Departments.Events;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Interface.Interfaces;

namespace LodgerPms.Domain.Departments.CommandHandlers
{
    public class DepartmentGroupCommandHandler : CommandHandler,
        IHandler<RegisterNewDepartmentGroupCommand>,
        IHandler<UpdateDepartmentGroupCommand>,
        IHandler<RemoveDepartmentGroupCommand>
    {
        private readonly IDepartmentGroupRepository _departmentRepository;
        private readonly IBus Bus;

        public DepartmentGroupCommandHandler(IDepartmentGroupRepository DepartmentRepository,
                                      IUnitOfWork uow,
                                      IBus bus,
                                      IDomainNotificationHandler<DomainNotification> notifications)
            :base(uow, bus, notifications)
        {
            _departmentRepository = DepartmentRepository;

            Bus = bus;
        }

        public void Handle(RegisterNewDepartmentGroupCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var department = DepartmentGroup.Create(message.Id,message.Code, message.Description);

            if (_departmentRepository.GetByDescription(department.Description) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Department Group Description has already been taken."));
                return;
            }

            _departmentRepository.Add(department);

            if (Commit())
            {
                Bus.RaiseEvent(new DepartmentGroupRegisteredEvent(department.Code, department.Description ));
            }
        }

        public void Handle(UpdateDepartmentGroupCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var department = DepartmentGroup.Create(message.Id, message.Code,  message.Description);
            var existingDepartment = _departmentRepository.GetByDescription(department.Description);

            if (existingDepartment != null)
            {
                if (!existingDepartment.Equals(department))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType,"The Department group description has already been taken."));
                    return;
                }
            }

            _departmentRepository.Update(department);

            if (Commit())
            {
                Bus.RaiseEvent(new DepartmentGroupUpdatedEvent( department.Id, department.Code, department.Description ));
            }
        }

        public void Handle(RemoveDepartmentGroupCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }
            var department = _departmentRepository.GetById(message.Id);
          //  _departmentRepository.Delete(department);

            if (Commit())
            {
                Bus.RaiseEvent(new DepartmentGroupRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
             _departmentRepository.Dispose();
        }
    }
}