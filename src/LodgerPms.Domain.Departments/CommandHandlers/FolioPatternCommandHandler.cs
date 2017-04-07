

using LodgerPms.Domain.Core.Bus;
using LodgerPms.Domain.Core.Events;
using LodgerPms.Domain.Core.Notifications;
using LodgerPms.Domain.Departments.CommandHandlers;
using LodgerPms.Domain.Departments.Commands;
using LodgerPms.Domain.Departments.Events;
using LodgerPms.Domain.Departments.Interfaces;
using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Interface.Interfaces;

namespace LodgerPms.Domain.folioPatterns.CommandHandlers
{
    public class FolioPatternCommandHandler : CommandHandler,
        IHandler<RegisterNewFolioPatternCommand>,
        IHandler<UpdateFolioPatternCommand>,
        IHandler<RemoveFolioPatternCommand>
    {
        private readonly IFolioPatternRepository _folioPatternRepository;
        private readonly IBus Bus;

        public FolioPatternCommandHandler(IFolioPatternRepository folioPatternRepository,
                                      IUnitOfWork uow,
                                      IBus bus,
                                      IDomainNotificationHandler<DomainNotification> notifications)
            :base(uow, bus, notifications)
        {
            _folioPatternRepository = folioPatternRepository;

            Bus = bus;
        }

        public void Handle(RegisterNewFolioPatternCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var folioPattern = FolioPattern.Create(message.Code, message.Description);

            if (_folioPatternRepository.GetByDescription(folioPattern.Description) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The folio Pattern Description has already been taken."));
                return;
            }

            _folioPatternRepository.Add(folioPattern);

            if (Commit())
            {
                Bus.RaiseEvent(new FolioPatternRegisteredEvent(folioPattern.Code, folioPattern.Description ));
            }
        }

        public void Handle(UpdateFolioPatternCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var folioPattern = FolioPattern.Create( message.Code,  message.Description);
            var existingfolioPattern = _folioPatternRepository.GetByDescription(folioPattern.Description);

            if (existingfolioPattern != null)
            {
                if (!existingfolioPattern.Equals(folioPattern))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType,"The folio Pattern  description has already been taken."));
                    return;
                }
            }

            _folioPatternRepository.Update(folioPattern);

            if (Commit())
            {
                Bus.RaiseEvent(new FolioPatternUpdatedEvent( folioPattern.Id, folioPattern.Code, folioPattern.Description ));
            }
        }

        public void Handle(RemoveFolioPatternCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }
            var folioPattern = _folioPatternRepository.GetById(message.Id);
            _folioPatternRepository.Remove(folioPattern.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new FolioPatternRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
             _folioPatternRepository.Dispose();
        }
    }
}