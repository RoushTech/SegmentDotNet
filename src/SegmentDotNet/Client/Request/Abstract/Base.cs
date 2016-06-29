namespace SegmentDotNet.Client.Request.Abstract
{
    using Interfaces;
    using Newtonsoft.Json;
    using Populators.Contexts;
    using Populators.Integrations;

    public abstract class Base : ISegmentRequest
    {
        public Base(
            Context context,
            Integrations integrations)
        {
            this.Context = context;
            this.Integrations = integrations;
        }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("integrations")]
        public Integrations Integrations { get; set; }

        public abstract string Endpoint { get; }
    }
}