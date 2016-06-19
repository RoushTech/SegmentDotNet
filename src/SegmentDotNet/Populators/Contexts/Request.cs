namespace SegmentDotNet.Populators.Contexts
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Features;
    using System.Collections.Generic;

    public class Request : IContextUpdater
    {
        public Request(IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;
        }

        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        public void UpdatePopulator(IDictionary<string, object> properties)
        {
            var context = this.HttpContextAccessor.HttpContext;
            properties.Add("ip", context.Features.Get<IHttpConnectionFeature>().RemoteIpAddress.ToString());
            properties.Add("page.path", context.Request.Path.ToString());
            if (context.Request.Headers.ContainsKey("Referer"))
            {
                properties.Add("page.referrer", context.Request.Headers["Referer"].ToString());
            }

            if (context.Request.Headers.ContainsKey("User-Agent"))
            {
                properties.Add("userAgent", context.Request.Headers["User-Agent"].ToString());
            }

            properties.Add("url", $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
        }
    }
}
