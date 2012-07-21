using FluentValidation;
using ThreeBytes.ProjectHollywood.News.List.Entities;

namespace ThreeBytes.ProjectHollywood.News.List.Validations.Abstract
{
    public interface INewsListNewsArticleValidatorResolver
    {
        IValidator<NewsListNewsArticle> CreateValidator();
        IValidator<NewsListNewsArticle> RenameValidator();
        IValidator<NewsListNewsArticle> UpdateContentValidator();
        IValidator<NewsListNewsArticle> DeleteValidator();
    }
}
