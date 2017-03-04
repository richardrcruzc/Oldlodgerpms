using System;

namespace LodgerPms.CoreLibs.Bus
{
    [Obsolete]
    public interface IHandlerRegistrar
    {
        void RegisterHandler<T>(Action<T> handler) where T : IMessage;
    }
}