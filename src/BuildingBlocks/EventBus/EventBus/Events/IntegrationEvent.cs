﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public Guid Id  { get; }
        public DateTime CreationDate { get; }
    }
}
