using System.Runtime.Serialization;

namespace DustyPig.TVDB.Models
{
    public enum Meta
    {
        [EnumMember(Value = @"translations")]
        Translations = 0,

        [EnumMember(Value = @"episodes")]
        Episodes = 1,
    }
}
