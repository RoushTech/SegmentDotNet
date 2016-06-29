namespace SegmentDotNet.PropertyContainers.Interfaces
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public interface IPropertyContainer
    {
        [JsonIgnore]
        Dictionary<string, object> Properties { get; set; }
    }
}
