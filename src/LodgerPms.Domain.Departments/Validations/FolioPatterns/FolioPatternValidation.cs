using FluentValidation;
using LodgerPms.Domain.Departments.Commands;

namespace LodgerPms.Domain.Departments.Validations
{
    public abstract class FolioPatternValidation<T> : AbstractValidator<T> where T : FolioPatternCommand
    {
        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        //protected void ValidateBirthDate()
        //{
        //    RuleFor(c => c.BirthDate)
        //        .NotEmpty()
        //        .Must(HaveMinimumAge)
        //        .WithMessage("The Department must have 18 years or more");
        //}

        //protected void ValidateEmail()
        //{
        //    RuleFor(c => c.Email)
        //        .NotEmpty()
        //        .EmailAddress();
        //}

        //protected void ValidateId()
        //{
        //    RuleFor(c => c.Id)
        //        .NotEqual(Guid.Empty);
        //}

        //protected static bool HaveMinimumAge(DateTime birthDate)
        //{
        //    return birthDate <= DateTime.Now.AddYears(-18);
        //}
    }
}
