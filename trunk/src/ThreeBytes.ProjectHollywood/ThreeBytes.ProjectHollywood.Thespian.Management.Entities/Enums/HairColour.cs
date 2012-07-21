using System.ComponentModel;
using ThreeBytes.Core.Enum.Converters;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Entities.Enums
{
    [TypeConverter(typeof(PascalCaseWordSplittingEnumConverter))]
    public enum HairColour
    {
        LightMidBrown
    }
}
