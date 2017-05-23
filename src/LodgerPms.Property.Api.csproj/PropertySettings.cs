using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api
{
    public class PropertySettings
    {
        public string ConnectionString { get; set; }
        public string ExternalCatalogBaseUrl { get; set; }
        public string EventBusConnection { get; set; }
    }
}
