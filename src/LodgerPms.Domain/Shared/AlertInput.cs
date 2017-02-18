using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Shared
{
      public class AlertInput : AgregateRoot.AlertInputState
    {
        public static AlertInput New(string code, string area, string description)
        {
            var obj = new AlertInput
            {
                Code = code,
                Area = area,
                Description = description
            };

            return obj;
        }
        public void Update(string id, string code, string area, string description)
        {
            this.Id = id;
            this.Code = code;
            this.Area = area;
            this.Description = description;
        }
        
        public AlertInput()
        { }
        public string Code { get; private set; }
        public string Area { get; private set; }
        public string Description { get; private set; }
    }
}
