using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DustyPig.TVDB.Converters
{
    internal class BoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    string strVal = reader.GetString();
                    if (bool.TryParse(strVal, out bool boolResult))
                        return boolResult;
                    if (int.TryParse(strVal, out int intResult))
                        return Convert.ToBoolean(intResult);
                    break;

                case JsonTokenType.Number:
                    int intVal = reader.GetInt32();
                    return Convert.ToBoolean(intVal);

                case JsonTokenType.True:
                    return true;
            }

            return false;
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(Convert.ToInt32(value));
        }
    }
}
