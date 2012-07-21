using System.Web;
using FluentValidation;

namespace ThreeBytes.ProjectHollywood.Host.Validations.Abstract
{
    public interface IPersistImageValidatorResolver
    {
        IValidator<HttpPostedFileBase> CreateValidator();
    }
}
