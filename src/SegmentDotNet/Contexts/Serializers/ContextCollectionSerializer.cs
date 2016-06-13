namespace SegmentDotNet.Contexts.Serializers
{
    using System;
    using Newtonsoft.Json;

    public class ContextCollectionSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ContextCollection) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contextCollection = value as ContextCollection;
            writer.WriteStartObject();
            foreach (var context in contextCollection.Contexts)
            {
                writer.WritePropertyName(context.Key);
                serializer.Serialize(writer, context);
            }

            writer.WriteEndObject();
        }
    }
}
