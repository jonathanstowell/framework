using FluentValidation;
using ThreeBytes.ProjectHollywood.News.List.Entities;

namespace ThreeBytes.ProjectHollywood.News.List.Validations.Concrete.Validators
{
    public class RenameNewsListNewsArticleValidator : AbstractValidator<NewsListNewsArticle>
    {
        public RenameNewsListNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
            RuleFor(x => x.Title).NotEmpty().Length(1, 100).WithMessage("'Title' must be a string with a maximum length of 100.");
        }
    }
}