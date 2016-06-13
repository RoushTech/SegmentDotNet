namespace SegmentDotNet.Contexts
{
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System.Linq;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GoogleAnalyitics : IContext
    {
        public GoogleAnalyitics(IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;
        }

        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        public string Key { get { return "Google Analyitics"; } }

        [JsonProperty("clientId")]
        public string ClientId { get { return this.GetGoogleAnalyticsCookie(); } }

        private string GetGoogleAnalyticsCookie()
        {
            var cookie = this.HttpContextAccessor.HttpContext.Request.Cookies["_ga"];
            return cookie == null ? null : string.Join(".", cookie.Split('.').Reverse().Take(2).Reverse());
        }
    }
}
