namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Screen : AnonymousBase
    {
        public Screen(IDateTime datetime)
            : base(datetime)
        {

        }

        public override string Type { get { return "screen"; } }

        public override string Endpoint { get { return "screen"; } }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
