using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.ProjectHollywood.Team.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.Team.Management.Validations.Concrete.Resolvers
{
    public class TeamManagementEmployeeValidatorResolver : ITeamManagementEmployeeValidatorResolver
    {
        private readonly Func<CreateTeamManagementEmployeeValidator> createTeamManagementEmployeeValidator;
        private readonly Func<RenameTeamManagementEmployeeValidator> renameTeamManagementEmployeeValidator;
        private readonly Func<RenameTeamManagementEmployeeJobValidator> renameTeamManagementEmployeeJobValidator;
        private readonly Func<UpdateTeamEmployeeSummaryValidator> updateTeamEmployeeSummaryValidator;
        private readonly Func<DeleteTeamManagementEmployeeValidator> deleteTeamManagementEmployeeValidator;
        private readonly Func<UpdateTeamManagementEmployeeProfileImageValidator> updateTeamProfileImageValidator;

        public TeamManagementEmployeeValidatorResolver(Func<CreateTeamManagementEmployeeValidator> createTeamManagementEmployeeValidator, Func<RenameTeamManagementEmployeeValidator> renameTeamManagementEmployeeValidator, Func<DeleteTeamManagementEmployeeValidator> deleteTeamManagementEmployeeValidator, Func<RenameTeamManagementEmployeeJobValidator> renameTeamManagementEmployeeJobValidator, Func<UpdateTeamEmployeeSummaryValidator> updateTeamEmployeeSummaryValidator, Func<UpdateTeamManagementEmployeeProfileImageValidator> updateTeamProfileImageValidator)
        {
            this.createTeamManagementEmployeeValidator = createTeamManagementEmployeeValidator;
            this.renameTeamManagementEmployeeValidator = renameTeamManagementEmployeeValidator;
            this.deleteTeamManagementEmployeeValidator = deleteTeamManagementEmployeeValidator;
            this.renameTeamManagementEmployeeJobValidator = renameTeamManagementEmployeeJobValidator;
            this.updateTeamEmployeeSummaryValidator = updateTeamEmployeeSummaryValidator;
            this.updateTeamProfileImageValidator = updateTeamProfileImageValidator;
        }

        public IValidator<TeamManagementEmployee> CreateValidator()
        {
            return createTeamManagementEmployeeValidator();
        }

        public IValidator<TeamManagementEmployee> RenameValidator()
        {
            return renameTeamManagementEmployeeValidator();
        }

        public IValidator<TeamManagementEmployee> RenameJobValidator()
        {
            return renameTeamManagementEmployeeJobValidator();
        }

        public IValidator<TeamManagementEmployee> UpdateSummaryValidator()
        {
            return updateTeamEmployeeSummaryValidator();
        }

        public IValidator<TeamManagementEmployee> UpdateProfileImageValidator()
        {
            return updateTeamProfileImageValidator();
        }

        public IValidator<TeamManagementEmployee> DeleteValidator()
        {
            return deleteTeamManagementEmployeeValidator();
        }
    }
}
