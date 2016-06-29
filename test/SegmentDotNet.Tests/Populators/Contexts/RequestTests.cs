namespace SegmentDotNet.Tests.Populators.Contexts
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Features;
    using Moq;
    using SegmentDotNet.Populators.Contexts;
    using System.Collections.Generic;
    using System.Net;
    using Xunit;

    public class RequestTests
    {
        [Fact]
        public void Updates_Dictionary()
        {
            var dictionary = this.UpdateDictionary(this.SetupMock().Object);
            Assert.Equal("127.0.0.1", dictionary["ip"]);
            Assert.Equal("/test/url.txt", dictionary["page.path"]);
            Assert.Equal("http://segment.com", dictionary["page.referrer"]);
            Assert.Equal("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36", dictionary["userAgent"]);
            Assert.Equal("http://segment.com/test/url.txt", dictionary["url"]);
        }

        [Fact]
        public void Handles_Missing_Referer()
        {
            var dictionary = this.UpdateDictionary(this.SetupMock(addReferer: false).Object);
            Assert.False(dictionary.ContainsKey("page.referrer"));
        }

        [Fact]
        public void Handles_Missing_User_Agent()
        {
            var dictionary = this.UpdateDictionary(this.SetupMock(addUserAgent: false).Object);
            Assert.False(dictionary.ContainsKey("userAgent"));
        }

        protected IDictionary<string, object> UpdateDictionary(IHttpContextAccessor mock)
        {
            var request = new Request(mock);
            var dictionary = new Dictionary<string, object>();
            request.UpdatePopulator(dictionary);
            return dictionary;
        }

        protected Mock<IHttpContextAccessor> SetupMock(bool addReferer = true, bool addUserAgent = true)
        {
            var contextAccessorMock = new Mock<IHttpContextAccessor>();
            contextAccessorMock.Setup(c => c.HttpContext.Features.Get<IHttpConnectionFeature>().RemoteIpAddress).Returns(IPAddress.Parse("127.0.0.1"));
            contextAccessorMock.Setup(c => c.HttpContext.Request.Path).Returns("/test/url.txt");
            contextAccessorMock.Setup(c => c.HttpContext.Request.Scheme).Returns("http");
            contextAccessorMock.Setup(c => c.HttpContext.Request.Host).Returns(new HostString("segment.com"));
            var headerDictionary = new HeaderDictionary();
            if(addReferer)
                headerDictionary.Add("Referer", "http://segment.com");
            if(addUserAgent)
                headerDictionary.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36");
            contextAccessorMock.Setup(c => c.HttpContext.Request.Headers).Returns(headerDictionary);
            return contextAccessorMock;
        }
    }
}
