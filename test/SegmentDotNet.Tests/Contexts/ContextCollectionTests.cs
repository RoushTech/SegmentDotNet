namespace SegmentDotNet.Tests.Contexts
{
    using Newtonsoft.Json;
    using SegmentDotNet.Contexts;
    using SegmentDotNet.Contexts.Interfaces;
    using Xunit;

    public class ContextCollectionTests
    {
        protected class ContextMock : IContext
        {
            public string Key { get { return "Context Mock"; } }

            [JsonProperty("test")]
            public string Test { get { return "value"; } }
        }

        protected class ContextMock2 : IContext
        {
            public string Key { get { return "Context Mock2"; } }

            [JsonProperty("test2")]
            public string Test { get { return "value2"; } }
        }

        [Fact]
        public void Serialization_Works()
        {
            var contextCollection = new ContextCollection();
            contextCollection.Add(new ContextMock());
            var json = JsonConvert.SerializeObject(contextCollection);
            Assert.Equal("{\"Context Mock\":{\"test\":\"value\"}}", json);
        }

        [Fact]
        public void Serialization_Multiple_Contexts_Works()
        {
            var contextCollection = new ContextCollection();
            contextCollection.Add(new ContextMock());
            contextCollection.Add(new ContextMock2());
            var json = JsonConvert.SerializeObject(contextCollection);
            Assert.Equal("{\"Context Mock\":{\"test\":\"value\"},\"Context Mock2\":{\"test2\":\"value2\"}}", json);
        }
    }
}
