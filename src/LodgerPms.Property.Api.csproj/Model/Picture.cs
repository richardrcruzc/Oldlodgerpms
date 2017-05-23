

using LodgerPms.Domain.SeedWork;

namespace LodgerPms.Property.Api.Model
{
    public class Picture
         : Entity
    {
        public string PictureUri { get; set; }
        public string Description { get; set; }
    }
}
