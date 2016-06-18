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
            var json = this.SetupClient().Serialize(this.SetupRequest<Alias>());
            var jsonObject = JsonConvert.DeserializeAnonymousType(json, new { timestamp = "" });
            Assert.Equal("2016-06-12T05:20:50.523Z", jsonObject.timestamp);
        }

        [Fact]
        public async Task Can_Identify()
        {
            var identify = this.SetupRequest<Identify>();
            identify.UserId = "1234";
            await this.SetupClient().Identify(identify);
        }

        [Fact]
        public async Task Can_Group()
        {
            var group = this.SetupRequest<Group>();
            group.GroupId = "G1234";
            group.UserId = "1234";
            await this.SetupClient().Group(group);
        }

        [Fact]
        public async Task Can_Track()
        {
            var track = this.SetupRequest<Track>();
            track.UserId = "1234";
            track.Event = "Can_Track Test";
            await this.SetupClient().Track(track);
        }

        [Fact]
        public async Task Can_Page()
        {
            var page = this.SetupRequest<Page>();
            page.UserId = "1234";
            page.Name = "Can_Page Test";
            await this.SetupClient().Page(page);
        }

        [Fact]
        public async Task Can_Screen()
        {
            var screen = this.SetupRequest<Screen>();
            screen.UserId = "1234";
            screen.Name = "Can_Screen Test";
            await this.SetupClient().Screen(screen);
        }

        [Fact]
        public async Task Can_Alias()
        {
            var alias = this.SetupRequest<Alias>();
            alias.PreviousId = "P1234";
            alias.UserId = "1234";
            await this.SetupClient().Alias(alias);
        }

        [Fact]
        public async Task Can_Batch()
        {
            var identify = this.SetupRequest<Identify>();
            identify.UserId = "B1234";
            var batch = new Batch();
            batch.Items.Add(identify);
            await this.SetupClient().Batch(batch);
        }

        [Fact]
        public async Task Should_Error_On_Large_Json()
        {
            var page = this.SetupRequest<Page>();
            page.UserId = "1234";
            page.Name = new string('a', 102400);
            await Assert.ThrowsAsync<Exception>(async () => await this.SetupClient().Page(page));
        }

        public void Dispose()
        {
        }
    }
}
