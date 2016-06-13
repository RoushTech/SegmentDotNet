namespace SegmentDotNet.Client.Request.Abstract
{
    using Contexts;
    using Interfaces;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public abstract class Base : ISegmentRequest
    {
        public Base()
        {
            this.Context = new ContextCollection();
        }

        [JsonProperty("context")]
        public ContextCollection Context { get; set; }

        [JsonProperty("integrations")]
        public Dictionary<string, string> Integrations { get; set; }

        public abstract string Endpoint { get; }
    }
}