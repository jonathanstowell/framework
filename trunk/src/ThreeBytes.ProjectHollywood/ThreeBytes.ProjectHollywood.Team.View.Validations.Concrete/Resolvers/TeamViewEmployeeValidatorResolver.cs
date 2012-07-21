using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.View.Entities;
using ThreeBytes.ProjectHollywood.Team.View.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.View.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.Team.View.Validations.Concrete.Resolvers
{
    public class TeamViewEmployeeValidatorResolver : ITeamViewEmployeeValidatorResolver
    {
        private readonly Func<CreateTeamViewEmployeeValidator> createTeamViewEmployeeValidator;
        private readonly Func<RenameTeamViewEmployeeValidator> renameTeamViewEmployeeValidator;
        private readonly Func<RenameTeamViewEmployeeJobValidator> renameTeamViewEmployeeJobValidator;
        private readonly Func<UpdateTeamViewEmployeeSummaryValidator> updateTeamViewEmployeeSummaryValidator;
        private readonly Func<UpdateTeamViewEmployeeProfileImageValidator> updateTeamProfileImageValidator;
        private readonly Func<DeleteTeamViewEmployeeValidator> deleteTeamViewEmployeeValidator;

        public TeamViewEmployeeValidatorResolver(Func<CreateTeamViewEmployeeValidator> createTeamViewEmployeeValidator, Func<RenameTeamViewEmployeeValidator> renameTeamViewEmployeeValidator, Func<DeleteTeamViewEmployeeValidator> deleteTeamViewEmployeeValidator, Func<RenameTeamViewEmployeeJobValidator> renameTeamViewEmployeeJobValidator, Func<UpdateTeamViewEmployeeSummaryValidator> updateTeamViewEmployeeSummaryValidator, Func<UpdateTeamViewEmployeeProfileImageValidator> updateTeamProfileImageValidator)
        {
            this.createTeamViewEmployeeValidator = createTeamViewEmployeeValidator;
            this.renameTeamViewEmployeeValidator = renameTeamViewEmployeeValidator;
            this.deleteTeamViewEmployeeValidator = deleteTeamViewEmployeeValidator;
            this.renameTeamViewEmployeeJobValidator = renameTeamViewEmployeeJobValidator;
            this.updateTeamViewEmployeeSummaryValidator = updateTeamViewEmployeeSummaryValidator;
            this.updateTeamProfileImageValidator = updateTeamProfileImageValidator;
        }

        public IValidator<TeamViewEmployee> CreateValidator()
        {
            return createTeamViewEmployeeValidator();
        }

        public IValidator<TeamViewEmployee> RenameValidator()
        {
            return renameTeamViewEmployeeValidator();
        }

        public IValidator<TeamViewEmployee> RenameJobValidator()
        {
            return renameTeamViewEmployeeJobValidator();
        }

        public IValidator<TeamViewEmployee> UpdateSummaryValidator()
        {
            return updateTeamViewEmployeeSummaryValidator();
        }

        public IValidator<TeamViewEmployee> UpdateProfileImageValidator()
        {
            return updateTeamProfileImageValidator();
        }

        public IValidator<TeamViewEmployee> DeleteValidator()
        {
            return deleteTeamViewEmployeeValidator();
        }
    }
}
