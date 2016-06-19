namespace SegmentDotNet.Client.Request.Abstract
{
    using Abstractions;
    using Newtonsoft.Json;
    using Populators.Contexts;
    using Populators.Integrations;

    public abstract class AnonymousBase : UserTimestampBase
    {
        public AnonymousBase(Context context, IDateTime datetime, Integrations integrations) : base(context, datetime, integrations)
        {
        }

        [JsonProperty("anonymousId")]
        public string AnonymousId { get; set; }
    }
}
