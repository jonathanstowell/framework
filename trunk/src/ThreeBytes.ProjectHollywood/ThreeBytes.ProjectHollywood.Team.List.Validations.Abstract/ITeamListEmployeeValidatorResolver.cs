using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.List.Entities;

namespace ThreeBytes.ProjectHollywood.Team.List.Validations.Abstract
{
    public interface ITeamListEmployeeValidatorResolver
    {
        IValidator<TeamListEmployee> CreateValidator();
        IValidator<TeamListEmployee> RenameValidator();
        IValidator<TeamListEmployee> RenameJobValidator();
        IValidator<TeamListEmployee> UpdateProfileImageValidator();
        IValidator<TeamListEmployee> DeleteValidator();
    }
}
