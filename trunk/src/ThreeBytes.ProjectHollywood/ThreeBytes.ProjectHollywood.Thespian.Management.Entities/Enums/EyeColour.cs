using System.ComponentModel;
using ThreeBytes.Core.Enum.Converters;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Entities.Enums
{
    [TypeConverter(typeof(PascalCaseWordSplittingEnumConverter))]
    public enum EyeColour
    {
        LightBlue,
        Blue,
        DarkBlue,
        BlueGreen,
        LightGreen,
        Green,
        DarkGreen,
        LightBrown,
        Brown,
        DarkBrown,
        Hazel,
        Grey,
        Violet
    }
}
