namespace SegmentDotNet.PropertyContainers.Serializers
{
    using Interfaces;
    using Json;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Reflection;

    public class PropertyContainerBaseSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IPropertyContainer).GetTypeInfo().IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var propertyContainer = value as IPropertyContainer;
            var valueToken = JToken.FromObject(value, new ForcedObjectSerializer());
            if (propertyContainer.Properties != null)
            {
                var propertiesToken = JToken.FromObject(propertyContainer.Properties);
                foreach (var property in propertiesToken.Children<JProperty>())
                {
                    valueToken[property.Name] = property.Value;
                }
            }

            valueToken.WriteTo(writer);
        }
    }
}
