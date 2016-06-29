
namespace SegmentDotNet.Client.Request
{
    using System;
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;
    using Populators.Contexts;
    using Populators.Integrations;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Alias : UserTimestampBase
    {
        public Alias(Context context, IDateTime datetime, Integrations integrations) : base(context, datetime, integrations)
        {
        }

        public override string Type {  get { return "alias"; } }

        public override string Endpoint { get { return "alias"; } }

        [JsonProperty("previousId")]
        public string PreviousId { get; set; }
    }
}
