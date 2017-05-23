﻿
using LodgerPms.Property.Api.Infrastructure.Data;
using LodgerPms.Property.Api.Infrastructure.Exceptions;
using System;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.Infrastructure.Idempotency
{
    public class RequestManager : IRequestManager
    {
        private readonly PropertyContext _context;

        public RequestManager(PropertyContext context)
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
                throw new PropertyDomainException($"Request with {id} already exists") : 
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
