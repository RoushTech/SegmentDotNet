namespace SegmentDotNet.Contexts
{
    using Interfaces;
    using Newtonsoft.Json;
    using Serializers;
    using System.Collections.Generic;

    [JsonConverter(typeof(ContextCollectionSerializer))]
    public class ContextCollection
    {
        public ContextCollection()
        {
            this.Contexts = new List<IContext>();
        }

        public List<IContext> Contexts { get; set; }

        public void Add(IContext context)
        {
            this.Contexts.Add(context);
        }
    }
}
