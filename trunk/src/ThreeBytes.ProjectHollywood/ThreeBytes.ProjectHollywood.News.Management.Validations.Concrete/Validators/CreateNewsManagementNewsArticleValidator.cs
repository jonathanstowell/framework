using FluentValidation;
using ThreeBytes.ProjectHollywood.News.Management.Entities;

namespace ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Validators
{
    public class CreateNewsManagementNewsArticleValidator : AbstractValidator<NewsManagementNewsArticle>
    {
        public CreateNewsManagementNewsArticleValidator()
        {
            RuleFor(x => x.CreatedBy).NotEmpty().Length(1, 35).WithMessage("'Created By' must be a string with a maximum length of 35.");
            RuleFor(x => x.Title).NotEmpty().Length(1, 100).WithMessage("'Title' must be a string with a maximum length of 100.");
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
