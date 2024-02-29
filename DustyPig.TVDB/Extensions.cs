using System;
using System.Runtime.Serialization;

namespace DustyPig.TVDB
{
    static class Extensions
    {
        private static readonly DateTime Epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static int ToUnixEpochTime(this DateTime time)
        {
            return (int)(time - Epoch).TotalSeconds;
        }


        public static string ConvertToString(this Enum value)
        {
            string name = Enum.GetName(value.GetType(), value);
            if (name != null)
            {
                var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                if (field != null)
                {
                    if (System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                        return attribute.Value ?? name;
                }
            }

            return value.ToString();
        }
    }
}
