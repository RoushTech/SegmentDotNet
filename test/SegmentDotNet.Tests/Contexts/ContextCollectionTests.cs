namespace SegmentDotNet.Tests.Contexts
{
    using Newtonsoft.Json;
    using SegmentDotNet.Contexts;
    using SegmentDotNet.Contexts.Abstract;
    using Xunit;

    public class ContextCollectionTests
    {
        protected class ContextMock : ContextBase
        {
            public override string Key { get { return "Context Mock"; } }

            [JsonProperty("test")]
            public string Test { get { return "value"; } }
        }

        protected class ContextMock2 : ContextBase
        {
            public override string Key { get { return "Context Mock2"; } }

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

        [Fact]
        public void Serialization_With_Custom_Params()
        {
            var contextCollection = new ContextCollection();
            var contextMock = new ContextMock();
            contextMock.Properties = new { custom1 = 1, custom2 = "custom222" };
            contextCollection.Add(contextMock);
            var json = JsonConvert.SerializeObject(contextCollection);
            Assert.Equal("{\"Context Mock\":{\"test\":\"value\",\"custom1\":1,\"custom2\":\"custom222\"}}", json);
        }

        [Fact]
        public void Serialization_With_Nested_Custom_Params()
        {
            var nestedContextCollection = new ContextCollection();
            var contextMock2 = new ContextMock();
            contextMock2.Properties = new { custom1 = "nested test" };
            nestedContextCollection.Add(contextMock2);
            var contextCollection = new ContextCollection();
            var contextMock = new ContextMock();
            contextMock.Properties = new { custom1 = nestedContextCollection };
            contextCollection.Add(contextMock);
            var json = JsonConvert.SerializeObject(contextCollection);
            Assert.Equal("{\"Context Mock\":{\"test\":\"value\",\"custom1\":{\"Context Mock\":{\"test\":\"value\",\"custom1\":\"nested test\"}}}}", json);
        }
    }
}
