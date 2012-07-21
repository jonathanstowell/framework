using FluentValidation;
using ThreeBytes.ProjectHollywood.News.Management.Entities;

namespace ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Validators
{
    public class DeleteNewsManagementNewsArticleValidator : AbstractValidator<NewsManagementNewsArticle>
    {
        public DeleteNewsManagementNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
        }
    }
}