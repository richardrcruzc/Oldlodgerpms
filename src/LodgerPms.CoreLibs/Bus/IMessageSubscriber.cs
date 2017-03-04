using System;
using System.Reactive;

namespace LodgerPms.CoreLibs.Bus
{
    public interface IMessageSubscriber : IDisposable
    {
        IObservable<Unit> Subscribe();
        event EventHandler<MessageReceivedEventArgs> MessageReceived;
    }
}