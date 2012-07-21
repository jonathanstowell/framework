using System.ComponentModel;

namespace ThreeBytes.Core.Enum.Extensions
{
    public static class ConversionExtensions
    {
        public static string ToStringUsingConverter<T>(this System.Enum e)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return converter.ConvertToString(e);
        }
    }
}
