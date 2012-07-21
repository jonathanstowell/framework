using FluentValidation;
using ThreeBytes.ProjectHollywood.News.Management.Entities;

namespace ThreeBytes.ProjectHollywood.News.Management.Validations.Abstract
{
    public interface INewsManagementNewsArticleValidatorResolver
    {
        IValidator<NewsManagementNewsArticle> CreateValidator();
        IValidator<NewsManagementNewsArticle> RenameValidator();
        IValidator<NewsManagementNewsArticle> UpdateContentValidator();
        IValidator<NewsManagementNewsArticle> DeleteValidator();
    }
}
