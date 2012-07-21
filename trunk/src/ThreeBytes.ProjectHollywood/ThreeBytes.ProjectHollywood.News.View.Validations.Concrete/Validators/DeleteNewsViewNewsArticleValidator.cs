using FluentValidation;
using ThreeBytes.ProjectHollywood.News.View.Entities;

namespace ThreeBytes.ProjectHollywood.News.View.Validations.Concrete.Validators
{
    public class DeleteNewsViewNewsArticleValidator : AbstractValidator<NewsViewNewsArticle>
    {
        public DeleteNewsViewNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
        }
    }
}