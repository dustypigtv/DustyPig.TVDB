using System.Runtime.Serialization;

namespace DustyPig.TVDB.Models
{
    public enum SeasonTypes
    {
        [EnumMember(Value = @"default")]
        Default,

        [EnumMember(Value = @"official")]
        Official,

        [EnumMember(Value = @"dvd")]
        DVD,

        [EnumMember(Value = @"absolute")]
        Absolute,

        [EnumMember(Value = @"alternate")]
        Alternate,

        [EnumMember(Value = @"regional")]
        Regional
    }
}
