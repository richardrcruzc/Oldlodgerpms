using LodgerPms.Domain.Core.Events;
using LodgerPms.Domain.Departments.Events;

namespace LodgerPms.Domain.Departments.EventHandlers
{
    public class FolioPatternEventHandler :
        IHandler<FolioPatternRegisteredEvent>,
        IHandler<FolioPatternUpdatedEvent>,
        IHandler<FolioPatternRemovedEvent>
    {
        public void Handle(FolioPatternUpdatedEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(FolioPatternRegisteredEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(FolioPatternRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}