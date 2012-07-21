using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThreeBytes.Core.Validations.Abstract
{
    public interface IDataAnnotationsValidator
    {
        bool TryValidate(object @object, out ICollection<ValidationResult> results);
    }
}
