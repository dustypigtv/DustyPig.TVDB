using System.Runtime.Serialization;

namespace DustyPig.TVDB.Models
{
    public enum Action
    {
        [EnumMember(Value = @"delete")]
        Delete = 0,

        [EnumMember(Value = @"update")]
        Update = 1,

    }

}
