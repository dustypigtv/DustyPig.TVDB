using System.Runtime.Serialization;

namespace DustyPig.TVDB.Models
{
    public enum SeriesFilterSort
    {
        [EnumMember(Value = @"score")]
        Score,

        [EnumMember(Value = @"firstAired")]
        FirstAired,

        [EnumMember(Value = @"lastAired")]
        LastAired,

        [EnumMember(Value = @"name")]
        Name
    }
}
