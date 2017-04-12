using System;
using LodgerPms.Domain.Core.Bus;
using LodgerPms.Domain.Core.Events;
using LodgerPms.Domain.Core.Notifications;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.Domain.Departments.Commands;
using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Departments.Events;
using LodgerPms.Domain.Interface.Interfaces;

namespace LodgerPms.Domain.Departments.CommandHandlers
{
    public class DepartmentCommandHandler : CommandHandler,
        IHandler<RegisterNewDepartmentCommand>,
        IHandler<UpdateDepartmentCommand>,
        IHandler<RemoveDepartmentCommand>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IBus Bus;

        public DepartmentCommandHandler(IDepartmentRepository DepartmentRepository,
                                      IUnitOfWork uow,
                                      IBus bus,
                                      IDomainNotificationHandler<DomainNotification> notifications)
            :base(uow, bus, notifications)
        {
            _departmentRepository = DepartmentRepository;

            Bus = bus;
        }

        public void Handle(RegisterNewDepartmentCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var department = Department.Create(message.Id,message.DepartmentGroup, message.DepartmentType, message.Description,message.ApplyTax, message.Amount,message.Percentage);

            if (_departmentRepository.GetByDescription(department.Description) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Department Description has already been taken."));
                return;
            }

            _departmentRepository.Add(department);

            if (Commit())
            {
                Bus.RaiseEvent(new DepartmentRegisteredEvent(department.DepartmentGroup, department.DepartmentType, department.Description, department.ApplyTax, department.Amount, department.Percentage));
            }
        }

        public void Handle(UpdateDepartmentCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var department = Department.Create(message.Id, message.DepartmentGroup, message.DepartmentType, message.Description, message.ApplyTax, message.Amount, message.Percentage);
            var existingDepartment = _departmentRepository.GetByDescription(department.Description);

            if (existingDepartment != null)
            {
                if (!existingDepartment.Equals(department))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType,"The Department description has already been taken."));
                    return;
                }
            }

            _departmentRepository.Update(department);

            if (Commit())
            {
                Bus.RaiseEvent(new DepartmentUpdatedEvent(department.DepartmentGroup, department.DepartmentType, department.Description, department.ApplyTax, department.Amount, department.Percentage));
            }
        }

        public void Handle(RemoveDepartmentCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }
            var department = _departmentRepository.GetById(message.Id);
           _departmentRepository.Remove(department.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new DepartmentRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            _departmentRepository.Dispose();
        }
    }
}