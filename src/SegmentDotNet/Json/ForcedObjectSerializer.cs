namespace SegmentDotNet.Json
{
    using Newtonsoft.Json;

    internal class ForcedObjectSerializer : JsonSerializer
    {
        public ForcedObjectSerializer()
            : base()
        {
            this.ContractResolver = new ForcedObjectResolver();
        }
    }
}
