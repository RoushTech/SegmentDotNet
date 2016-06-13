namespace SegmentDotNet.Contexts.Interfaces
{
    using Newtonsoft.Json;

    public interface IContext
    {
        [JsonIgnore]
        string Key { get; }
    }
}
