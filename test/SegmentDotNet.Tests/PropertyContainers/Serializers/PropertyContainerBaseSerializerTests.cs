namespace SegmentDotNet.Tests.PropertyContainers.Serializers
{
    using Moq;
    using SegmentDotNet.PropertyContainers.Interfaces;
    using SegmentDotNet.PropertyContainers.Serializers;
    using System;
    using Xunit;

    public class PropertyContainerBaseSerializerTests
    {
        [Fact]
        public void Cannot_ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new PropertyContainerBaseSerializer().ReadJson(null, null, null, null));
        }

        [Fact]
        public void Valid_CanConvert()
        {
            var propertyContainer = new Mock<IPropertyContainer>();
            Assert.True(new PropertyContainerBaseSerializer().CanConvert(propertyContainer.Object.GetType()));
        }

        [Fact]
        public void Inalid_CanConvert()
        {
            Assert.False(new PropertyContainerBaseSerializer().CanConvert(typeof(string)));
        }
    }
}
