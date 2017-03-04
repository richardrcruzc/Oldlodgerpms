using System;
using System.Reactive;
using LodgerPms.CoreLibs.Domain;

namespace LodgerPms.CoreLibs.Bus.Amqp
{
    public abstract class AmqpCommandHandlerBase<TCommand> : IAmqpCommandHandler<TCommand>
        where TCommand : Command
    {
        protected IUnitOfWork UnitOfWork;

        protected AmqpCommandHandlerBase(IUnitOfWork uow)
        {
            Guard.NotNull(uow);
            UnitOfWork = uow;
        }

        public abstract IObservable<Unit> Handle(TCommand message);
    }
}