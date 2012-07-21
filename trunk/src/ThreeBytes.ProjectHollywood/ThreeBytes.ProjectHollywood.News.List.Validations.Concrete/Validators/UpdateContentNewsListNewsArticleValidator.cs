using FluentValidation;
using ThreeBytes.ProjectHollywood.News.List.Entities;

namespace ThreeBytes.ProjectHollywood.News.List.Validations.Concrete.Validators
{
    public class UpdateContentNewsListNewsArticleValidator : AbstractValidator<NewsListNewsArticle>
    {
        public UpdateContentNewsListNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
