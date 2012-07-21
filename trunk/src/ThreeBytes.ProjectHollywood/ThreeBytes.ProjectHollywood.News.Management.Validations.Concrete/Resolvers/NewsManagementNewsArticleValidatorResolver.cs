using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Resolvers
{
    public class NewsManagementNewsArticleValidatorResolver : INewsManagementNewsArticleValidatorResolver
    {
        private readonly Func<CreateNewsManagementNewsArticleValidator> createNewsManagementNewsArticleValidator;
        private readonly Func<RenameNewsManagementNewsArticleValidator> renameNewsManagementNewsArticleValidator;
        private readonly Func<UpdateContentNewsManagementNewsArticleValidator> updateContentNewsManagementNewsArticleValidator;
        private readonly Func<DeleteNewsManagementNewsArticleValidator> deleteNewsManagementNewsArticleValidator;

        public NewsManagementNewsArticleValidatorResolver(Func<CreateNewsManagementNewsArticleValidator> createNewsManagementNewsArticleValidator, Func<RenameNewsManagementNewsArticleValidator> renameNewsManagementNewsArticleValidator, Func<DeleteNewsManagementNewsArticleValidator> deleteNewsManagementNewsArticleValidator, Func<UpdateContentNewsManagementNewsArticleValidator> updateContentNewsManagementNewsArticleValidator)
        {
            this.createNewsManagementNewsArticleValidator = createNewsManagementNewsArticleValidator;
            this.renameNewsManagementNewsArticleValidator = renameNewsManagementNewsArticleValidator;
            this.deleteNewsManagementNewsArticleValidator = deleteNewsManagementNewsArticleValidator;
            this.updateContentNewsManagementNewsArticleValidator = updateContentNewsManagementNewsArticleValidator;
        }

        public IValidator<NewsManagementNewsArticle> CreateValidator()
        {
            return createNewsManagementNewsArticleValidator();
        }

        public IValidator<NewsManagementNewsArticle> RenameValidator()
        {
            return renameNewsManagementNewsArticleValidator();
        }

        public IValidator<NewsManagementNewsArticle> UpdateContentValidator()
        {
            return updateContentNewsManagementNewsArticleValidator();
        }

        public IValidator<NewsManagementNewsArticle> DeleteValidator()
        {
            return deleteNewsManagementNewsArticleValidator();
        }
    }
}
