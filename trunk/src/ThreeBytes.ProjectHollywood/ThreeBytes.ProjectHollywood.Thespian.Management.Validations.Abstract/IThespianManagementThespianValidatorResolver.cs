using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Abstract
{
    public interface IThespianManagementThespianValidatorResolver
    {
        IValidator<ThespianManagementThespian> CreateValidator();
        IValidator<ThespianManagementThespian> RenameValidator();
        IValidator<ThespianManagementThespian> UpdateProfileImageValidator();
        IValidator<ThespianManagementThespian> DeleteValidator();
    }
}
