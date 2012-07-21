using FluentValidation;
using ThreeBytes.ProjectHollywood.News.View.Entities;

namespace ThreeBytes.ProjectHollywood.News.View.Validations.Abstracts
{
    public interface INewsViewNewsArticleValidatorResolver
    {
        IValidator<NewsViewNewsArticle> CreateValidator();
        IValidator<NewsViewNewsArticle> RenameValidator();
        IValidator<NewsViewNewsArticle> UpdateContentValidator();
        IValidator<NewsViewNewsArticle> DeleteValidator();
    }
}
