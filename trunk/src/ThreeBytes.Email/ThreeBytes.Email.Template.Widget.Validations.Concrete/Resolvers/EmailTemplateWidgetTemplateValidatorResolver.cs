using System;
using FluentValidation;
using ThreeBytes.Email.Template.Widget.Entities;
using ThreeBytes.Email.Template.Widget.Validations.Abstract;
using ThreeBytes.Email.Template.Widget.Validations.Concrete.Validators;

namespace ThreeBytes.Email.Template.Widget.Validations.Concrete.Resolvers
{
    public class EmailTemplateWidgetTemplateValidatorResolver : IEmailTemplateWidgetTemplateValidatorResolver
    {
        private readonly Func<CreateEmailWidgetManagementTemplateValidator> createEmailTemplateWidgetTemplateValidator;
        private readonly Func<DeleteEmailTemplateWidgetTemplateValidator> deleteEmailTemplateWidgetTemplateValidator;
        private readonly Func<RenameEmailTemplateWidgetTemplateValidator> renameEmailTemplateWidgetTemplateValidator;

        public EmailTemplateWidgetTemplateValidatorResolver(Func<CreateEmailWidgetManagementTemplateValidator> createEmailTemplateWidgetTemplateValidator, Func<DeleteEmailTemplateWidgetTemplateValidator> deleteEmailTemplateWidgetTemplateValidator, Func<RenameEmailTemplateWidgetTemplateValidator> renameEmailTemplateWidgetTemplateValidator)
        {
            this.createEmailTemplateWidgetTemplateValidator = createEmailTemplateWidgetTemplateValidator;
            this.deleteEmailTemplateWidgetTemplateValidator = deleteEmailTemplateWidgetTemplateValidator;
            this.renameEmailTemplateWidgetTemplateValidator = renameEmailTemplateWidgetTemplateValidator;
        }

        public IValidator<EmailTemplateWidgetTemplate> CreateValidator()
        {
            return createEmailTemplateWidgetTemplateValidator();
        }

        public IValidator<EmailTemplateWidgetTemplate> DeleteValidator()
        {
            return deleteEmailTemplateWidgetTemplateValidator();
        }

        public IValidator<EmailTemplateWidgetTemplate> RenameValidator()
        {
            return renameEmailTemplateWidgetTemplateValidator();
        }
    }
}
