using LodgerPms.Departments.Api.Infrastructure.Exceptions;
using LodgerPms.Service.Departments.Api.Infrastructure;
using System; 
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Infrastructure.Idempotency
{
    public class RequestManager : IRequestManager
    {
        private readonly DepartmentContext _context;

        public RequestManager(DepartmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<bool> ExistAsync(Guid id)
        {
            var request = await _context.
                FindAsync<ClientRequest>(id);

            return request != null;
        }

        public async Task CreateRequestForCommandAsync<T>(Guid id)
        {
            var exists = await ExistAsync(id);

            var request = exists ?
                throw new DepartmentDomainException($"Request with {id} already exists") :
                new ClientRequest()
                {
                    Id = id,
                    Name = typeof(T).Name,
                    Time = DateTime.UtcNow
                };

            _context.Add(request);

            await _context.SaveChangesAsync();
        }
    }
}
