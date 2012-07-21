using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.News.View.Entities;
using ThreeBytes.ProjectHollywood.News.View.Validations.Abstracts;
using ThreeBytes.ProjectHollywood.News.View.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.News.View.Validations.Concrete.Resolvers
{
    public class NewsViewNewsArticleValidatorResolver : INewsViewNewsArticleValidatorResolver
    {
        private readonly Func<CreateNewsViewNewsArticleValidator> createNewsManagementNewsArticleValidator;
        private readonly Func<RenameNewsViewNewsArticleValidator> renameNewsManagementNewsArticleValidator;
        private readonly Func<UpdateContentNewsViewNewsArticleValidator> updateContentNewsManagementNewsArticleValidator;
        private readonly Func<DeleteNewsViewNewsArticleValidator> deleteNewsManagementNewsArticleValidator;

        public NewsViewNewsArticleValidatorResolver(Func<CreateNewsViewNewsArticleValidator> createNewsManagementNewsArticleValidator, Func<RenameNewsViewNewsArticleValidator> renameNewsManagementNewsArticleValidator, Func<DeleteNewsViewNewsArticleValidator> deleteNewsManagementNewsArticleValidator, Func<UpdateContentNewsViewNewsArticleValidator> updateContentNewsManagementNewsArticleValidator)
        {
            this.createNewsManagementNewsArticleValidator = createNewsManagementNewsArticleValidator;
            this.renameNewsManagementNewsArticleValidator = renameNewsManagementNewsArticleValidator;
            this.deleteNewsManagementNewsArticleValidator = deleteNewsManagementNewsArticleValidator;
            this.updateContentNewsManagementNewsArticleValidator = updateContentNewsManagementNewsArticleValidator;
        }

        public IValidator<NewsViewNewsArticle> CreateValidator()
        {
            return createNewsManagementNewsArticleValidator();
        }

        public IValidator<NewsViewNewsArticle> RenameValidator()
        {
            return renameNewsManagementNewsArticleValidator();
        }

        public IValidator<NewsViewNewsArticle> UpdateContentValidator()
        {
            return updateContentNewsManagementNewsArticleValidator();
        }

        public IValidator<NewsViewNewsArticle> DeleteValidator()
        {
            return deleteNewsManagementNewsArticleValidator();
        }
    }
}
