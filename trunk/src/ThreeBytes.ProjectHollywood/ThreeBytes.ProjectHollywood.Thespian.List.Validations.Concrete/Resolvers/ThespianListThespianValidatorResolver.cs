using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;
using ThreeBytes.ProjectHollywood.Thespian.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.List.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Validations.Concrete.Resolvers
{
    public class ThespianListThespianValidatorResolver : IThespianListThespianValidatorResolver
    {
        private readonly Func<CreateThespianListThespianValidator> createThespianListThespianValidation;
        private readonly Func<RenameThespianListThespianValidator> renameThespianListManagementThespianValidation;
        private readonly Func<UpdateThespianListThespianProfileImageValidator> updateTeamProfileImageValidator;
        private readonly Func<DeleteThespianListThespianValidator> deleteThespianListThespianValidation;

        public ThespianListThespianValidatorResolver(Func<CreateThespianListThespianValidator> createThespianListThespianValidation, Func<RenameThespianListThespianValidator> renameThespianListManagementThespianValidation, Func<DeleteThespianListThespianValidator> deleteThespianListThespianValidation, Func<UpdateThespianListThespianProfileImageValidator> updateTeamProfileImageValidator)
        {
            this.createThespianListThespianValidation = createThespianListThespianValidation;
            this.renameThespianListManagementThespianValidation = renameThespianListManagementThespianValidation;
            this.deleteThespianListThespianValidation = deleteThespianListThespianValidation;
            this.updateTeamProfileImageValidator = updateTeamProfileImageValidator;
        }

        public IValidator<ThespianListThespian> CreateValidator()
        {
            return createThespianListThespianValidation();
        }

        public IValidator<ThespianListThespian> RenameValidator()
        {
            return renameThespianListManagementThespianValidation();
        }

        public IValidator<ThespianListThespian> UpdateProfileImageValidator()
        {
            return updateTeamProfileImageValidator();
        }

        public IValidator<ThespianListThespian> DeleteValidator()
        {
            return deleteThespianListThespianValidation();
        }
    }
}
