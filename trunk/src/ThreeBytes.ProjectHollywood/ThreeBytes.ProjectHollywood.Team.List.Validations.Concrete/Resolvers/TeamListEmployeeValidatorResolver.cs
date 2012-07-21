using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.List.Entities;
using ThreeBytes.ProjectHollywood.Team.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.List.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.Team.List.Validations.Concrete.Resolvers
{
    public class TeamListEmployeeValidatorResolver : ITeamListEmployeeValidatorResolver
    {
        private readonly Func<CreateTeamListEmployeeValidator> createTeamListEmployeeValidator;
        private readonly Func<RenameTeamListEmployeeValidator> renameTeamListEmployeeValidator;
        private readonly Func<RenameTeamListEmployeeJobValidator> renameTeamListEmployeeJobValidator;
        private readonly Func<DeleteTeamListEmployeeValidator> deleteTeamListEmployeeValidator;
        private readonly Func<UpdateTeamListEmployeeProfileImageValidator> updateTeamProfileImageValidator;

        public TeamListEmployeeValidatorResolver(Func<CreateTeamListEmployeeValidator> createTeamListEmployeeValidator, Func<RenameTeamListEmployeeValidator> renameTeamListEmployeeValidator, Func<DeleteTeamListEmployeeValidator> deleteTeamListEmployeeValidator, Func<RenameTeamListEmployeeJobValidator> renameTeamListEmployeeJobValidator, Func<UpdateTeamListEmployeeProfileImageValidator> updateTeamProfileImageValidator)
        {
            this.createTeamListEmployeeValidator = createTeamListEmployeeValidator;
            this.renameTeamListEmployeeValidator = renameTeamListEmployeeValidator;
            this.deleteTeamListEmployeeValidator = deleteTeamListEmployeeValidator;
            this.renameTeamListEmployeeJobValidator = renameTeamListEmployeeJobValidator;
            this.updateTeamProfileImageValidator = updateTeamProfileImageValidator;
        }

        public IValidator<TeamListEmployee> CreateValidator()
        {
            return createTeamListEmployeeValidator();
        }

        public IValidator<TeamListEmployee> RenameValidator()
        {
            return renameTeamListEmployeeValidator();
        }

        public IValidator<TeamListEmployee> RenameJobValidator()
        {
            return renameTeamListEmployeeJobValidator();
        }

        public IValidator<TeamListEmployee> UpdateProfileImageValidator()
        {
            return updateTeamProfileImageValidator();
        }

        public IValidator<TeamListEmployee> DeleteValidator()
        {
            return deleteTeamListEmployeeValidator();
        }
    }
}
