namespace SegmentDotNet.Tests.Contexts.Serializers
{
    using SegmentDotNet.Contexts;
    using SegmentDotNet.Contexts.Serializers;
    using System;
    using Xunit;

    public class ContextBaseSerializerTests
    {
        [Fact]
        public void Cannot_ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new ContextBaseSerializer().ReadJson(null, null, null, null));
        }

        [Fact]
        public void Valid_CanConvert()
        {
            Assert.True(new ContextBaseSerializer().CanConvert(typeof(GoogleAnalyitics)));
        }

        [Fact]
        public void Inalid_CanConvert()
        {
            Assert.False(new ContextBaseSerializer().CanConvert(typeof(string)));
        }
    }
}
