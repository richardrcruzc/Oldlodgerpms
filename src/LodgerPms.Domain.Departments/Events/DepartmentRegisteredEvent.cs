﻿using System;
using LodgerPms.Domain.Core.Events;
using LodgerPms.Domain.Departments.Models;

namespace LodgerPms.Domain.Departments.Events
{
    public class DepartmentGroupRegisteredEvent : Event
    {
        public DepartmentGroupRegisteredEvent(string code,  string description )
        {
            // Id = id;
            Code = code;
            Description = description;
        }
        public string Id { get; set; }
        public string Code { get; set; }      
        public string Description { get; private set; }

    }
}