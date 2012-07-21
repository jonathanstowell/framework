using System;
using FluentValidation;
using ThreeBytes.ProjectHollywood.News.List.Entities;
using ThreeBytes.ProjectHollywood.News.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.News.List.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.News.List.Validations.Concrete.Resolvers
{
    public class NewsListNewsArticleValidatorResolver : INewsListNewsArticleValidatorResolver
    {
        private readonly Func<CreateNewsListNewsArticleValidator> createNewsListNewsArticleValidator;
        private readonly Func<RenameNewsListNewsArticleValidator> renameNewsListNewsArticleValidator;
        private readonly Func<UpdateContentNewsListNewsArticleValidator> updateContentNewsListNewsArticleValidator;
        private readonly Func<DeleteNewsListNewsArticleValidator> deleteNewsListNewsArticleValidator;

        public NewsListNewsArticleValidatorResolver(Func<CreateNewsListNewsArticleValidator> createNewsListNewsArticleValidator, Func<RenameNewsListNewsArticleValidator> renameNewsListNewsArticleValidator, Func<DeleteNewsListNewsArticleValidator> deleteNewsListNewsArticleValidator, Func<UpdateContentNewsListNewsArticleValidator> updateContentNewsListNewsArticleValidator)
        {
            this.createNewsListNewsArticleValidator = createNewsListNewsArticleValidator;
            this.renameNewsListNewsArticleValidator = renameNewsListNewsArticleValidator;
            this.deleteNewsListNewsArticleValidator = deleteNewsListNewsArticleValidator;
            this.updateContentNewsListNewsArticleValidator = updateContentNewsListNewsArticleValidator;
        }

        public IValidator<NewsListNewsArticle> CreateValidator()
        {
            return createNewsListNewsArticleValidator();
        }

        public IValidator<NewsListNewsArticle> RenameValidator()
        {
            return renameNewsListNewsArticleValidator();
        }

        public IValidator<NewsListNewsArticle> UpdateContentValidator()
        {
            return updateContentNewsListNewsArticleValidator();
        }

        public IValidator<NewsListNewsArticle> DeleteValidator()
        {
            return deleteNewsListNewsArticleValidator();
        }
    }
}
