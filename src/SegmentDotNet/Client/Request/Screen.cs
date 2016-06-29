namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;
    using Populators.Contexts;
    using Populators.Integrations;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Screen : AnonymousBase
    {
        public Screen(Context context, IDateTime datetime, Integrations integrations) : base(context, datetime, integrations)
        {
        }

        public override string Type { get { return "screen"; } }

        public override string Endpoint { get { return "screen"; } }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
