namespace SegmentDotNet.PropertyContainers.Abstract
{
    using Interfaces;
    using Newtonsoft.Json;
    using Serializers;
    using System.Collections.Generic;

    [JsonConverter(typeof(PropertyContainerBaseSerializer))]
    public abstract class PropertyContainerBase : IPropertyContainer
    {        
        public PropertyContainerBase()
        {
            this.Properties = new Dictionary<string, object>();
        }
        
        public Dictionary<string, object> Properties { get; set; }
    }
}
