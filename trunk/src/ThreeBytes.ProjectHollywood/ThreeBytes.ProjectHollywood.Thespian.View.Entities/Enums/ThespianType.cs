using System.ComponentModel;
using ThreeBytes.Core.Enum.Converters;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Entities.Enums
{
    [TypeConverter(typeof(PascalCaseWordSplittingEnumConverter))]
    public enum ThespianType
    {
        Artist,
        Creative,
        ArtistCreative
    }
}
