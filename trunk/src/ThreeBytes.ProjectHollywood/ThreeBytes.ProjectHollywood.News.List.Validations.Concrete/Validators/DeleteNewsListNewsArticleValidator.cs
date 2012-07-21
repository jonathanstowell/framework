using FluentValidation;
using ThreeBytes.ProjectHollywood.News.List.Entities;

namespace ThreeBytes.ProjectHollywood.News.List.Validations.Concrete.Validators
{
    public class DeleteNewsListNewsArticleValidator : AbstractValidator<NewsListNewsArticle>
    {
        public DeleteNewsListNewsArticleValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("News Article does not exist");
        }
    }
}