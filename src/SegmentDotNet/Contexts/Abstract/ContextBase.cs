namespace SegmentDotNet.Contexts.Abstract
{
    using Interfaces;
    using Newtonsoft.Json;
    using Serializers;

    [JsonConverter(typeof(ContextBaseSerializer))]
    public abstract class ContextBase : IContext
    {
        public abstract string Key { get; }
        
        [JsonIgnore]
        public object Properties { get; set; }
    }
}
