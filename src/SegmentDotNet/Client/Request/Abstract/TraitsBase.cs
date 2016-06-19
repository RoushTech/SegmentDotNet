namespace SegmentDotNet.Client.Request.Abstract
{
    using Abstractions;
    using Newtonsoft.Json;
    using Populators.Traits;
    using Populators.Contexts;
    using Populators.Integrations;

    public abstract class TraitsBase : AnonymousBase
    {
        public TraitsBase(Context context, IDateTime datetime, Integrations integrations, Traits traits) : base(context, datetime, integrations)
        {
            this.Traits = traits;
        }

        [JsonProperty("traits")]
        public Traits Traits { get; set; }
    }
}
