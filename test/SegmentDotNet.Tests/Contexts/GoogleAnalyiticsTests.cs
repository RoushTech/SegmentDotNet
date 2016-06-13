namespace SegmentDotNet.Tests.Contexts
{
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SegmentDotNet.Client.Request;
    using SegmentDotNet.Contexts;
    using Xunit;

    public class GoogleAnalyiticsTest : TestBase
    {
        [Fact]
        public void Parses_Google_Analyitics_Cookie()
        {
            var googleAnalyitics = this.SetupGoogleAnalyitics();
            Assert.Equal("1033501218.1368477899", googleAnalyitics.ClientId);
        }

        [Fact]
        public void Serialize_With_Extensions()
        {
            var track = this.SetupRequest<Track>();
            track.Context.Add(this.SetupGoogleAnalyitics());
            var context = JObject.Parse(this.SetupClient().Serialize(track))["context"];
            Assert.Equal("{\"Google Analytics\":{\"clientId\":\"1033501218.1368477899\"}}", context.ToString(Formatting.None));
        }

        protected GoogleAnalyitics SetupGoogleAnalyitics()
        {
            var gaCookie = "GA1.2.1033501218.1368477899";
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(h => h.HttpContext.Request.Cookies["_ga"]).Returns(gaCookie);
            return new GoogleAnalyitics(httpContextAccessorMock.Object);
        }
    }
}
