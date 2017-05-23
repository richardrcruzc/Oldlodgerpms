using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LodgerPms.Property.Api.Infrastructure.Commands
{
    public class IdentifiedCommand<T, R> : IAsyncRequest<R>
        where T : IAsyncRequest<R>
    {
        public T Command { get; }
        public Guid Id { get; }
        public IdentifiedCommand(T command, Guid id)
        {
            Command = command;
            Id = id;
        }
    }
}
