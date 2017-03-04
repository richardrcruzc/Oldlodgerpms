using System;
using System.Reactive;

namespace LodgerPms.CoreLibs.Bus
{
    public interface IEventBus
    {
        IObservable<Unit> Publish<T>(T @event) where T : Event;
    }
}