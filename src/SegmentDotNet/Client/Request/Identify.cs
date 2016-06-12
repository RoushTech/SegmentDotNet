namespace SegmentDotNet.Client.Request
{
    using Abstract;
    using Abstractions;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Identify : TraitsBase
    {
        public Identify(IDateTime datetime)
            : base(datetime)
        {

        }

        public override string Type { get { return "identify"; } }

        public override string Endpoint { get { return "identify"; } }
    }
}
