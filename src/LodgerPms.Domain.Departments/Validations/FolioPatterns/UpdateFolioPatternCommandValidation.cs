
using LodgerPms.Domain.Departments.Commands;

namespace LodgerPms.Domain.Departments.Validations
{
    public class UpdateFolioPatternCommandValidation : FolioPatternValidation<UpdateFolioPatternCommand>
    {
        public UpdateFolioPatternCommandValidation()
        {

            ValidateDescription();

        }
    }
}
