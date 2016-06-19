namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;
    using Populators.Traits;
    using Populators.Contexts;
    using Populators.Integrations;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Identify : TraitsBase
    {
        public Identify(Context context, IDateTime datetime, Integrations integrations, Traits traits) : base(context, datetime, integrations, traits)
        {
        }

        public override string Type { get { return "identify"; } }

        public override string Endpoint { get { return "identify"; } }
    }
}
