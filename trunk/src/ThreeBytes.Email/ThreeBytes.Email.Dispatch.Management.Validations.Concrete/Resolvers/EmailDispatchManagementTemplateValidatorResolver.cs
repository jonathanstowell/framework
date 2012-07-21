using System;
using FluentValidation;
using ThreeBytes.Email.Dispatch.Management.Entities;
using ThreeBytes.Email.Dispatch.Management.Validations.Abstract;
using ThreeBytes.Email.Dispatch.Management.Validations.Concrete.Validators;

namespace ThreeBytes.Email.Dispatch.Management.Validations.Concrete.Resolvers
{
    public class EmailDispatchManagementTemplateValidatorResolver : IEmailDispatchManagementTemplateValidatorResolver
    {
        private readonly Func<CreateEmailDispatchManagementTemplateValidator> createEmailTemplateViewTemplateValidation;
        private readonly Func<DeleteEmailDispatchManagementTemplateValidator> deleteEmailTemplateViewTemplateValidation;
        private readonly Func<RenameEmailDispatchManagementTemplateValidator> renameEmailTemplateViewTemplateValidation;
        private readonly Func<UpdateContentsEmailDispatchManagementTemplateValidator> updateContentsEmailTemplateViewTemplateValidation;
        private readonly Func<UpdateFromAddressEmailDispatchManagementTemplateValidator> updateFromAddressEmailTemplateViewTemplateValidation;

        public EmailDispatchManagementTemplateValidatorResolver(Func<CreateEmailDispatchManagementTemplateValidator> createEmailTemplateViewTemplateValidation, Func<DeleteEmailDispatchManagementTemplateValidator> deleteEmailTemplateViewTemplateValidation, Func<RenameEmailDispatchManagementTemplateValidator> renameEmailTemplateViewTemplateValidation, Func<UpdateContentsEmailDispatchManagementTemplateValidator> updateContentsEmailTemplateViewTemplateValidation, Func<UpdateFromAddressEmailDispatchManagementTemplateValidator> updateFromAddressEmailTemplateViewTemplateValidation)
        {
            this.createEmailTemplateViewTemplateValidation = createEmailTemplateViewTemplateValidation;
            this.deleteEmailTemplateViewTemplateValidation = deleteEmailTemplateViewTemplateValidation;
            this.renameEmailTemplateViewTemplateValidation = renameEmailTemplateViewTemplateValidation;
            this.updateContentsEmailTemplateViewTemplateValidation = updateContentsEmailTemplateViewTemplateValidation;
            this.updateFromAddressEmailTemplateViewTemplateValidation = updateFromAddressEmailTemplateViewTemplateValidation;
        }

        public IValidator<EmailDispatchManagementTemplate> CreateValidator()
        {
            return createEmailTemplateViewTemplateValidation();
        }

        public IValidator<EmailDispatchManagementTemplate> RenameValidator()
        {
            return renameEmailTemplateViewTemplateValidation();
        }

        public IValidator<EmailDispatchManagementTemplate> UpdateContentsValidator()
        {
            return updateContentsEmailTemplateViewTemplateValidation();
        }

        public IValidator<EmailDispatchManagementTemplate> UpdateFromAddressValidator()
        {
            return updateFromAddressEmailTemplateViewTemplateValidation();
        }

        public IValidator<EmailDispatchManagementTemplate> DeleteValidator()
        {
            return deleteEmailTemplateViewTemplateValidation();
        }
    }
}
