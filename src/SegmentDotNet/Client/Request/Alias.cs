
namespace SegmentDotNet.Client.Request
{
    using System;
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Alias : UserTimestampBase
    {
        public Alias(IDateTime datetime)
            : base(datetime)
        {

        }

        public override string Type {  get { return "alias"; } }

        public override string Endpoint { get { return "alias"; } }

        [JsonProperty("previousId")]
        public string PreviousId { get; set; }
    }
}
