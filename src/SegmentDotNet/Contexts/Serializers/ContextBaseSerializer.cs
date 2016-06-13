namespace SegmentDotNet.Contexts.Serializers
{
    using Abstract;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Reflection;
    
    public class ContextBaseSerializer : JsonConverter
    {
        protected object NestedLock = new object();

        protected bool Nested { get; set; }

        public override bool CanWrite { get { lock (this.NestedLock) { return true && !this.Nested; } } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ContextBase).GetTypeInfo().IsAssignableFrom(objectType) && !this.Nested;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contextBase = value as ContextBase;
            JToken valueToken;
            lock (this.NestedLock)
            {
                this.Nested = true;
                valueToken = JToken.FromObject(value);
                this.Nested = false;
            }

            if (contextBase.Properties != null)
            {
                var propertiesToken = JToken.FromObject(contextBase.Properties);
                foreach (var property in propertiesToken.Children<JProperty>())
                {
                    valueToken[property.Name] = property.Value;
                }
            }

            valueToken.WriteTo(writer);
        }
    }
}
