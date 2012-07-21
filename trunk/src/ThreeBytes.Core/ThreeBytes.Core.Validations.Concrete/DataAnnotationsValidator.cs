using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThreeBytes.Core.Validations.Abstract;

namespace ThreeBytes.Core.Validations.Concrete
{
    public class DataAnnotationsValidator : IDataAnnotationsValidator
    {
        public bool TryValidate(object @object, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(@object, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(
                @object, context, results,
                validateAllProperties: true
            );
        }
    }
}
