﻿using LodgerPms.Domain.Core.Events;
using LodgerPms.Domain.Departments.Events;

namespace LodgerPms.Domain.Departments.EventHandlers
{
    public class DepartmentGroupEventHandler :
        IHandler<DepartmentGroupRegisteredEvent>,
        IHandler<DepartmentGroupUpdatedEvent>,
        IHandler<FolioPatternRemovedEvent>
    {
        public void Handle(DepartmentGroupUpdatedEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(DepartmentGroupRegisteredEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(FolioPatternRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}