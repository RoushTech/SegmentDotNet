using System;

namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Group : TraitsBase
    {
        public Group(IDateTime datetime)
            : base(datetime)
        {

        }

        public override string Type { get { return "group"; } }

        public override string Endpoint {  get { return "group"; } }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }
    }
}
