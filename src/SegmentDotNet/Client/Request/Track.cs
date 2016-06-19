namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;
    using Populators.Contexts;
    using Populators.Integrations;
    using Populators.Properties;
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Track : AnonymousBase
    {
        public Track(Context context, IDateTime datetime, Integrations integrations, Properties properties) : base(context, datetime, integrations)
        {
            this.Properties = properties;
        }

        public override string Type { get { return "track"; } }

        public override string Endpoint { get { return "track"; } }
        
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }
}
