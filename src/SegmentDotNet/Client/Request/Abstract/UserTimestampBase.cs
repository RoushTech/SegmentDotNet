namespace SegmentDotNet.Client.Request.Abstract
{
    using Abstractions;
    using Newtonsoft.Json;
    using System;
    using Populators.Contexts;
    using Populators.Integrations;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class UserTimestampBase : Base
    {
        public UserTimestampBase(
            Context context,
            IDateTime datetime,
            Integrations integrations)
            : base(context, integrations)
        {
            this.DateTime = datetime;
        }

        protected IDateTime DateTime { get; set; }

        [JsonProperty("type")]
        public abstract string Type { get; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get { return this.DateTime.UtcNow; } }
    }
}
