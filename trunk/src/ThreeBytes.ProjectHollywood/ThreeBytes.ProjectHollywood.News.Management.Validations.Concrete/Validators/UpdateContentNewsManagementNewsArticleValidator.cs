using FluentValidation;
using ThreeBytes.ProjectHollywood.News.Management.Entities;

namespace ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Validators
{
    public class UpdateContentNewsManagementNewsArticleValidator : AbstractValidator<NewsManagementNewsArticle>
    {
        public UpdateContentNewsManagementNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
