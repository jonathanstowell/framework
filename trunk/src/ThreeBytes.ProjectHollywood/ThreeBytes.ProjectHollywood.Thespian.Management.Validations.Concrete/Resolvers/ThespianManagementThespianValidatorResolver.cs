using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Concrete.Resolvers
{
    public class ThespianManagementThespianValidatorResolver : IThespianManagementThespianValidatorResolver
    {
        private readonly Func<CreateThespianManagementThespianValidator> createThespianManagementThespianValidation;
        private readonly Func<RenameThespianManagementThespianValidator> renameThespianManagementThespianValidation;
        private readonly Func<UpdateThespianManagementThespianProfileImageValidator> updateTeamProfileImageValidator;
        private readonly Func<DeleteThespianManagementThespianValidator> deleteThespianManagementThespianValidation;

        public ThespianManagementThespianValidatorResolver(Func<CreateThespianManagementThespianValidator> createThespianManagementThespianValidation, Func<RenameThespianManagementThespianValidator> renameThespianManagementThespianValidation, Func<DeleteThespianManagementThespianValidator> deleteThespianManagementThespianValidation, Func<UpdateThespianManagementThespianProfileImageValidator> updateTeamProfileImageValidator)
        {
            this.createThespianManagementThespianValidation = createThespianManagementThespianValidation;
            this.renameThespianManagementThespianValidation = renameThespianManagementThespianValidation;
            this.deleteThespianManagementThespianValidation = deleteThespianManagementThespianValidation;
            this.updateTeamProfileImageValidator = updateTeamProfileImageValidator;
        }

        public IValidator<ThespianManagementThespian> CreateValidator()
        {
            return createThespianManagementThespianValidation();
        }

        public IValidator<ThespianManagementThespian> RenameValidator()
        {
            return renameThespianManagementThespianValidation();
        }

        public IValidator<ThespianManagementThespian> UpdateProfileImageValidator()
        {
            return updateTeamProfileImageValidator();
        }

        public IValidator<ThespianManagementThespian> DeleteValidator()
        {
            return deleteThespianManagementThespianValidation();
        }
    }
}
