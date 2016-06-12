namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Page : AnonymousBase
    {
        public Page(IDateTime datetime)
            : base(datetime)
        {

        }

        public override string Type { get { return "page"; } }

        public override string Endpoint { get { return "page"; } }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
