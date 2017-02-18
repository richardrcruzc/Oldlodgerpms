using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Shared
{

    public class Script : ValueObject<Script>
    {
        public Script(bool active, ScriptType scriptType, BelongType belongTo, string description)
        {
            this.Active = active;
            this.ScriptType = scriptType;
            this.BelongTo = belongTo;
            this.Description = description;
        }

        public Script() { }
        public bool Active { get; private set; }
        public ScriptType ScriptType { get; private set; }
        public BelongType BelongTo { get; private set; }

        public string Description { get; private set; }

        public DateTime DateCreated { get; private set; }
        public string CreateBy { get; private set; }

    }
    public enum ScriptType
    {
        Clossing = 1,
        Openning = 2,
        Email = 3,
        Phone = 4
    }
    public enum BelongType
    {
        Reservation = 1,
        Checking = 2
    }
}