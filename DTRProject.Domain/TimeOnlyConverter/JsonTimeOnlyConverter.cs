using System.Text.Json;
using System.Text.Json.Serialization;

namespace DTRProject.Domain.TimeOnlyConverter
{
    public class JsonTimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private const string Format = "HH:mm:ss"; // 24-hour format

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return TimeOnly.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
