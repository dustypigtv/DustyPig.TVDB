﻿using System.Runtime.Serialization;

namespace DustyPig.TVDB.Models
{
    public enum MovieFilterSort
    {
        [EnumMember(Value = @"score")]
        Score,

        [EnumMember(Value = @"firstAired")]
        FirstAired,

        [EnumMember(Value = @"name")]
        Name
    }
}
