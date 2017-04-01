using LodgerPms.Domain.Core.Events;
using LodgerPms.EventStoreSqlDataLayer.Repository.EventSourcing;
using LodgerPms.Infra.CrossCutting.Identity.Inteface;
using Newtonsoft.Json;


namespace LodgerPms.EventStoreSqlDataLayer.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Name);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
