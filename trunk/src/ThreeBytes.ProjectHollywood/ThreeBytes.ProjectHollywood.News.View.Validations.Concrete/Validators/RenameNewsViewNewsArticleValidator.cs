using FluentValidation;
using ThreeBytes.ProjectHollywood.News.View.Entities;

namespace ThreeBytes.ProjectHollywood.News.View.Validations.Concrete.Validators
{
    public class RenameNewsViewNewsArticleValidator : AbstractValidator<NewsViewNewsArticle>
    {
        public RenameNewsViewNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
            RuleFor(x => x.Title).NotEmpty().Length(1, 100).WithMessage("'Title' must be a string with a maximum length of 100.");
        }
    }
}