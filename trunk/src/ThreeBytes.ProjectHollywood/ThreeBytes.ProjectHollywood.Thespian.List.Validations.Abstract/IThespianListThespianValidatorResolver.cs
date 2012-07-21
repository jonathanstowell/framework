using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Validations.Abstract
{
    public interface IThespianListThespianValidatorResolver
    {
        IValidator<ThespianListThespian> CreateValidator();
        IValidator<ThespianListThespian> RenameValidator();
        IValidator<ThespianListThespian> UpdateProfileImageValidator();
        IValidator<ThespianListThespian> DeleteValidator();
    }
}
