using LodgerPms.Domain.Core.Events;
using LodgerPms.Domain.Departments.Events;

namespace LodgerPms.Domain.Departments.EventHandlers
{
    public class DepartmentEventHandler :
        IHandler<DepartmentRegisteredEvent>,
        IHandler<DepartmentUpdatedEvent>,
        IHandler<DepartmentRemovedEvent>
    {
        public void Handle(DepartmentUpdatedEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(DepartmentRegisteredEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(DepartmentRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}