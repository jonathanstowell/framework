using System.Web.Mvc;
using FluentValidation.Results;

namespace ThreeBytes.Core.Extensions.Validations
{
    public static class ModelStateExtension
    {
        public static void CopyTo(this ValidationResult result, ModelStateDictionary modelState)
        {
            CopyTo(result, modelState, null);
        }

        public static void CopyTo(this ValidationResult result, ModelStateDictionary modelState, string prefix)
        {
            prefix = string.IsNullOrEmpty(prefix) ? "" : prefix + ".";
            foreach (var propertyError in result.Errors)
            {
                string key = ExpressionHelper.GetExpressionText(propertyError.PropertyName);
                modelState.AddModelError(prefix + key, propertyError.ErrorMessage);
            }
        }
    }
}
