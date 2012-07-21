using FluentValidation;
using ThreeBytes.ProjectHollywood.News.Management.Entities;

namespace ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Validators
{
    public class RenameNewsManagementNewsArticleValidator : AbstractValidator<NewsManagementNewsArticle>
    {
        public RenameNewsManagementNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
            RuleFor(x => x.Title).NotEmpty().Length(1, 100).WithMessage("'Title' must be a string with a maximum length of 100.");
        }
    }
}