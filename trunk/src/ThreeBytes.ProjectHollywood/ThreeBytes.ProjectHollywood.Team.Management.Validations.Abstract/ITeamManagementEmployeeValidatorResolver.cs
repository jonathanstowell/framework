using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Team.Management.Validations.Abstract
{
    public interface ITeamManagementEmployeeValidatorResolver
    {
        IValidator<TeamManagementEmployee> CreateValidator();
        IValidator<TeamManagementEmployee> RenameValidator();
        IValidator<TeamManagementEmployee> RenameJobValidator();
        IValidator<TeamManagementEmployee> UpdateSummaryValidator();
        IValidator<TeamManagementEmployee> UpdateProfileImageValidator();
        IValidator<TeamManagementEmployee> DeleteValidator();
    }
}
