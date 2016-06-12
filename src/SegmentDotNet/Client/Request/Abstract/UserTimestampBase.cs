namespace SegmentDotNet.Client.Request.Abstract
{
    using Abstractions;
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class UserTimestampBase : Base
    {
        public UserTimestampBase(IDateTime datetime)
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
