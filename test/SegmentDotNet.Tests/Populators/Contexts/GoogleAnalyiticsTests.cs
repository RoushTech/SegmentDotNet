namespace SegmentDotNet.Tests.Populators.Contexts
{
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SegmentDotNet.Populators.Contexts;
    using System.Collections.Generic;
    using Xunit;

    public class GoogleAnalyiticsTest : TestBase
    {
        [Fact]
        public void Parses_Google_Analyitics_Cookie()
        {
            var googleAnalyitics = this.SetupGoogleAnalyitics();
            Assert.Equal("1033501218.1368477899", googleAnalyitics.Payload.ClientId);
        }

        [Fact]
        public void Serialize_With_Extensions()
        {
            var context = new Context(new List<IContext>() { this.SetupGoogleAnalyitics() });
            context.Prepare();
            var json = JObject.Parse(this.SetupClient().Serialize(context));
            Assert.Equal("{\"Google Analyitics\":{\"clientId\":\"1033501218.1368477899\"}}", json.ToString(Formatting.None));
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
