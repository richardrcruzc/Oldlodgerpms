﻿using System;
using System.Reactive;

namespace LodgerPms.CoreLibs.Bus.Amqp
{
    public interface IAmqpEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        IObservable<Unit> Handle(TEvent message);
    }
}