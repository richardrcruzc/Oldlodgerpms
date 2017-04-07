 using LodgerPms.Domain.Departments.Commands;

namespace LodgerPms.Domain.Departments.Validations
{
    public class RegisterNewFolioPatternCommandValidation : FolioPatternValidation<RegisterNewFolioPatternCommand>
    {
        public RegisterNewFolioPatternCommandValidation()
        {
            ValidateDescription();
        }
    }
}
