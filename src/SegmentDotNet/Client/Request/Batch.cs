namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Batch : Base
    {
        public Batch()
        {
            this.Items = new List<UserTimestampBase>();
        }

        public override string Endpoint { get { return "batch"; } }

        [JsonProperty("batch")]
        public List<UserTimestampBase> Items { get; set; }
    }
}
