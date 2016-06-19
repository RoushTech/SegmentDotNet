namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Populators.Contexts;
    using Populators.Integrations;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Batch : Base
    {
        public Batch(Context context, Integrations integrations) : base(context, integrations)
        {
            this.Items = new List<UserTimestampBase>();
        }

        public override string Endpoint { get { return "batch"; } }

        [JsonProperty("batch")]
        public List<UserTimestampBase> Items { get; set; }
    }
}
