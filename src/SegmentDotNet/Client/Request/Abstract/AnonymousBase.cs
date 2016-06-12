namespace SegmentDotNet.Client.Request.Abstract
{
    using Abstractions;
    using Newtonsoft.Json;

    public abstract class AnonymousBase : UserTimestampBase
    {
        public AnonymousBase(IDateTime datetime)
            : base(datetime)
        {

        }

        [JsonProperty("anonymousId")]
        public string AnonymousId { get; set; }
    }
}
