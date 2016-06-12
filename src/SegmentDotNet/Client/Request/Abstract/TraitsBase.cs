namespace SegmentDotNet.Client.Request.Abstract
{
    using Abstractions;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public abstract class TraitsBase : AnonymousBase
    {
        public TraitsBase(IDateTime datetime)
            : base(datetime)
        {

        }

        [JsonProperty("traits")]
        public Dictionary<string, string> Traits { get; set; }
    }
}
