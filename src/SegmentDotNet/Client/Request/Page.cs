namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;
    using Populators.Contexts;
    using Populators.Integrations;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Page : AnonymousBase
    {
        public Page(Context context, IDateTime datetime, Integrations integrations) : base(context, datetime, integrations)
        {
        }

        public override string Type { get { return "page"; } }

        public override string Endpoint { get { return "page"; } }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
