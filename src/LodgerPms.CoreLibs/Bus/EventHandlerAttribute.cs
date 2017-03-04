using System;

namespace LodgerPms.CoreLibs.Bus
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class EventHandlerAttribute : Attribute
    {
    }
}