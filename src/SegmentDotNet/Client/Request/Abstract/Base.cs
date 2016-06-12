namespace SegmentDotNet.Client.Request.Abstract
{
    using Interfaces;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public abstract class Base : ISegmentRequest
    {
        [JsonProperty("context")]
        public Dictionary<string, string> Context { get; set; }

        [JsonProperty("integrations")]
        public Dictionary<string, string> Integrations { get; set; }

        public abstract string Endpoint { get; }
    }
}