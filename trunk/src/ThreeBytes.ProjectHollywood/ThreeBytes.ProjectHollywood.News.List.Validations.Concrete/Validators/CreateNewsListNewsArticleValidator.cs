using FluentValidation;
using ThreeBytes.ProjectHollywood.News.List.Entities;

namespace ThreeBytes.ProjectHollywood.News.List.Validations.Concrete.Validators
{
    public class CreateNewsListNewsArticleValidator : AbstractValidator<NewsListNewsArticle>
    {
        public CreateNewsListNewsArticleValidator()
        {
            RuleFor(x => x.CreatedBy).NotNull().NotEmpty().Length(1, 35);
            RuleFor(x => x.Title).NotEmpty().Length(1, 100).WithMessage("'Title' must be a string with a maximum length of 100.");
            RuleFor(x => x.Content).NotEmpty().Length(1, 200).WithMessage("'Content' must be a string with a maximum length of 200.");
        }
    }
}
