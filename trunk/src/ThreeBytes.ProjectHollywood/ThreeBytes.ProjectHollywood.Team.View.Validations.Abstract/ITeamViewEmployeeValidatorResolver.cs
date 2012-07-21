using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.View.Entities;

namespace ThreeBytes.ProjectHollywood.Team.View.Validations.Abstract
{
    public interface ITeamViewEmployeeValidatorResolver
    {
        IValidator<TeamViewEmployee> CreateValidator();
        IValidator<TeamViewEmployee> RenameValidator();
        IValidator<TeamViewEmployee> RenameJobValidator();
        IValidator<TeamViewEmployee> UpdateSummaryValidator();
        IValidator<TeamViewEmployee> UpdateProfileImageValidator();
        IValidator<TeamViewEmployee> DeleteValidator();
    }
}
