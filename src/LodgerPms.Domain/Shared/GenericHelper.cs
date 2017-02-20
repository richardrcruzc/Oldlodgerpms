 using static LodgerPms.Domain.Shared.Enums;

namespace LodgerPms.Domain.Shared
{
    public class GenericHelper : Identity
    {
        public static GenericHelper CreateNew(GenericEntityType entityType, string description)
        {

            return new GenericHelper {
                Active = true,
                Description= description,
                EntityType= entityType,
            };

        }

        public  GenericHelper()
        {
        }

        public GenericEntityType EntityType { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public GenericHelper ChangeStatus()
        {
            Active = Active == true? false : true;
            return this;
        }
    }


}
