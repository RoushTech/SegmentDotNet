namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Track : AnonymousBase
    {
        public Track(IDateTime datetime)
            : base(datetime)
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
