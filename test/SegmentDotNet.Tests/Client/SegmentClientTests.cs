namespace SegmentDotNet.Tests.Client
{
    using Newtonsoft.Json;
    using SegmentDotNet.Client.Request;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;

    public class SegmentClientTests : TestBase, IDisposable
    {
        public SegmentClientTests()
        {
            // Tooling for this in the future would be amazing.
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SEGMENT_WRITE_KEY")))
            {
                var env = File.ReadAllText(".env");
                var lines = env.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    var segments = line.Split('=');
                    if (segments[0] == "SEGMENT_WRITE_KEY")
                    {
                        Environment.SetEnvironmentVariable("SEGMENT_WRITE_KEY", segments[1]);
                    }
                }
            }
        }

        [Fact]
        public void Should_Serialize_Timestamp()
        {
            var json = this.SetupClient().Serialize(new Alias(null, this.GetDateTimeMock(), null));
            var jsonObject = JsonConvert.DeserializeAnonymousType(json, new { timestamp = "" });
            Assert.Equal("2016-06-12T05:20:50.523Z", jsonObject.timestamp);
        }

        [Fact]
        public async Task Can_Identify()
        {
            var identify = new Identify(null, this.GetDateTimeMock(), null, null);
            identify.UserId = "1234";
            await this.SetupClient().Identify(identify);
        }

        [Fact]
        public async Task Can_Group()
        {
            var group = new Group(null, this.GetDateTimeMock(), null, null);
            group.GroupId = "G1234";
            group.UserId = "1234";
            await this.SetupClient().Group(group);
        }

        [Fact]
        public async Task Can_Track()
        {
            var track = new Track(null, this.GetDateTimeMock(), null);
            track.UserId = "1234";
            track.Event = "Can_Track Test";
            await this.SetupClient().Track(track);
        }

        [Fact]
        public async Task Can_Page()
        {
            var page = new Page(null, this.GetDateTimeMock(), null);
            page.UserId = "1234";
            page.Name = "Can_Page Test";
            await this.SetupClient().Page(page);
        }

        [Fact]
        public async Task Can_Screen()
        {
            var screen = new Screen(null, this.GetDateTimeMock(), null);
            screen.UserId = "1234";
            screen.Name = "Can_Screen Test";
            await this.SetupClient().Screen(screen);
        }

        [Fact]
        public async Task Can_Alias()
        {
            var alias = new Alias(null, this.GetDateTimeMock(), null);
            alias.PreviousId = "P1234";
            alias.UserId = "1234";
            await this.SetupClient().Alias(alias);
        }

        [Fact]
        public async Task Can_Batch()
        {
            var identify = new Identify(null, this.GetDateTimeMock(), null, null);
            identify.UserId = "B1234";
            var batch = new Batch(null, null);
            batch.Items.Add(identify);
            await this.SetupClient().Batch(batch);
        }

        [Fact]
        public async Task Should_Error_On_Large_Json()
        {
            var page = new Page(null, this.GetDateTimeMock(), null);
            page.UserId = "1234";
            page.Name = new string('a', 102400);
            await Assert.ThrowsAsync<Exception>(async () => await this.SetupClient().Page(page));
        }

        public void Dispose()
        {
        }
    }
}
