namespace SegmentDotNet.Tests.Contexts.Serializers
{
    using SegmentDotNet.Contexts;
    using SegmentDotNet.Contexts.Serializers;
    using System;
    using Xunit;

    public class ContextCollectionSerializerTests
    {
        [Fact]
        public void Cannot_ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new ContextCollectionSerializer().ReadJson(null, null, null, null));
        }

        [Fact]
        public void Valid_CanConvert()
        {
            Assert.True(new ContextCollectionSerializer().CanConvert(typeof(ContextCollection)));
        }

        [Fact]
        public void Inalid_CanConvert()
        {
            Assert.False(new ContextCollectionSerializer().CanConvert(typeof(string)));
        }
    }
}
