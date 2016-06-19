using System;

namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;
    using Populators.Traits;
    using Populators.Contexts;
    using Populators.Integrations;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Group : TraitsBase
    {
        public Group(Context context, IDateTime datetime, Integrations integrations, Traits traits) : base(context, datetime, integrations, traits)
        {
        }

        public override string Type { get { return "group"; } }

        public override string Endpoint {  get { return "group"; } }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }
    }
}
