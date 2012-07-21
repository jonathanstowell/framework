using FluentValidation;
using ThreeBytes.ProjectHollywood.News.View.Entities;

namespace ThreeBytes.ProjectHollywood.News.View.Validations.Concrete.Validators
{
    public class CreateNewsViewNewsArticleValidator : AbstractValidator<NewsViewNewsArticle>
    {
        public CreateNewsViewNewsArticleValidator()
        {
            RuleFor(x => x.CreatedBy).NotNull().NotEmpty().Length(1, 35);
            RuleFor(x => x.Title).NotEmpty().Length(1, 100).WithMessage("'Title' must be a string with a maximum length of 100.");
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
