using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;
using ThreeBytes.ProjectHollywood.Thespian.View.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.View.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Validations.Concrete.Resolvers
{
    public class ThespianViewThespianValidatorResolver : IThespianViewThespianValidatorResolver
    {
        private readonly Func<CreateThespianViewThespianValidator> createThespianViewThespianValidation;
        private readonly Func<RenameThespianViewThespianValidator> renameThespianViewThespianValidation;
        private readonly Func<UpdateThespianViewThespianProfileImageValidator> updateTeamProfileImageValidator;
        private readonly Func<DeleteThespianViewThespianValidator> deleteThespianViewThespianValidation;

        public ThespianViewThespianValidatorResolver(Func<CreateThespianViewThespianValidator> createThespianViewThespianValidation, Func<RenameThespianViewThespianValidator> renameThespianViewThespianValidation, Func<DeleteThespianViewThespianValidator> deleteThespianViewThespianValidation, Func<UpdateThespianViewThespianProfileImageValidator> updateTeamProfileImageValidator)
        {
            this.createThespianViewThespianValidation = createThespianViewThespianValidation;
            this.renameThespianViewThespianValidation = renameThespianViewThespianValidation;
            this.deleteThespianViewThespianValidation = deleteThespianViewThespianValidation;
            this.updateTeamProfileImageValidator = updateTeamProfileImageValidator;
        }

        public IValidator<ThespianViewThespian> CreateValidator()
        {
            return createThespianViewThespianValidation();
        }

        public IValidator<ThespianViewThespian> RenameValidator()
        {
            return renameThespianViewThespianValidation();
        }

        public IValidator<ThespianViewThespian> UpdateProfileImageValidator()
        {
            return updateTeamProfileImageValidator();
        }

        public IValidator<ThespianViewThespian> DeleteValidator()
        {
            return deleteThespianViewThespianValidation();
        }
    }
}
