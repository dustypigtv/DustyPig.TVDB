using System.Runtime.Serialization;

namespace DustyPig.TVDB.Models
{
    public enum SortType
    {
        [EnumMember(Value = @"asc")]
        Asc,

        [EnumMember(Value = @"desc")]
        Desc
    }
}
