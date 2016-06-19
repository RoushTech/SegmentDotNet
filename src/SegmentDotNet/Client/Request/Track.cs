namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Populators.Contexts;
    using Populators.Integrations;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Track : AnonymousBase
    {
        public Track(Context context, IDateTime datetime, Integrations integrations) : base(context, datetime, integrations)
        {
        }

        public override string Type { get { return "track"; } }

        public override string Endpoint { get { return "track"; } }
        
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, string> Properties { get; set; }
    }
}
