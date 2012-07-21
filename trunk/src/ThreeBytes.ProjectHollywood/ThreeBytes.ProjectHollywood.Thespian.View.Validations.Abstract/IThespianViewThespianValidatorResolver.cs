using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Validations.Abstract
{
    public interface IThespianViewThespianValidatorResolver
    {
        IValidator<ThespianViewThespian> CreateValidator();
        IValidator<ThespianViewThespian> RenameValidator();
        IValidator<ThespianViewThespian> UpdateProfileImageValidator();
        IValidator<ThespianViewThespian> DeleteValidator();
    }
}
