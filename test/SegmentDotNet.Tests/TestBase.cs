namespace SegmentDotNet.Tests
{
    using Moq;
    using Abstractions;
    using SegmentDotNet.Client.Request.Abstract;
    using System;
    using SegmentDotNet.Client;
    using Configuration;
    using Microsoft.Extensions.Options;
    public abstract class TestBase
    {
        protected SegmentClient SetupClient(string writeKey = null)
        {
            if (writeKey == null)
            {
                writeKey = Environment.GetEnvironmentVariable("SEGMENT_WRITE_KEY");
            }

            var optionsMock = new Mock<IOptions<SegmentConfiguration>>();
            var configurationMock = new Mock<SegmentConfiguration>();
            configurationMock.Setup(c => c.WriteKey).Returns(writeKey);
            optionsMock.Setup(o => o.Value).Returns(configurationMock.Object);
            var segmentClient = new SegmentClient(optionsMock.Object);
            return segmentClient;
        }

        protected T SetupRequest<T>()
            where T : UserTimestampBase
        {
            var datetimeMock = new Mock<IDateTime>();
            datetimeMock.Setup(d => d.UtcNow).Returns(new DateTime(2016, 6, 12, 5, 20, 50, 523, DateTimeKind.Utc));
            return Activator.CreateInstance(typeof(T), datetimeMock.Object) as T;
        }
    }
}
