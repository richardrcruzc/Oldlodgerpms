using MediatR;
using System;
 

namespace LodgerPms.Departments.Api.Application.Commands
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
