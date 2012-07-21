using FluentValidation;
using ThreeBytes.ProjectHollywood.News.View.Entities;

namespace ThreeBytes.ProjectHollywood.News.View.Validations.Concrete.Validators
{
    public class UpdateContentNewsViewNewsArticleValidator : AbstractValidator<NewsViewNewsArticle>
    {
        public UpdateContentNewsViewNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
