using System;

namespace LodgerPms.CoreLibs.Bus
{
    public interface IMessageConsumer : IDisposable
    {
        IMessageSubscriber Subscriber { get; }
    }
}