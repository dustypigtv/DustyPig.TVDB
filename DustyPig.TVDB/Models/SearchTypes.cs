using System.Runtime.Serialization;

namespace DustyPig.TVDB.Models
{
    public enum SearchTypes
    {
        [EnumMember(Value = @"movie")]
        Movie,

        [EnumMember(Value = @"series")]
        Series,

        [EnumMember(Value = @"person")]
        Person,

        [EnumMember(Value = @"company")]
        Company
    }
}
