using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Profiles
{
    public class ProfileAttribute
    {
        public ProfileAttribute(string description, string value) {
            this.Description = description;
            this.Value = value;
            this.Active = true;
        }
        public ProfileAttribute() { }
        public void ChangeStatus(bool status)
        {
            if (status == Active)
            {
                return;
            }
            {
                Active = status;
            }

        }
        public string Description { get; private set; }
        public string Value { get; private set; }
        public bool Active { get; private set; }
    }
}
