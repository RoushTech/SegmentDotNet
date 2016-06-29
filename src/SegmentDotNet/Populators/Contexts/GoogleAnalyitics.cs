namespace SegmentDotNet.Populators.Contexts
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Collections.Generic;
    
    public class GoogleAnalyitics : IContextUpdater
    {
        public class GoogleAnalyiticsPayload
        {
            [JsonProperty("clientId")]
            public string ClientId { get; set; }
        }

        public GoogleAnalyitics(IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;
            this.Payload = this.GeneratePayload();
        }

        private GoogleAnalyiticsPayload GeneratePayload()
        {
            return new GoogleAnalyiticsPayload
            {
                ClientId = this.GetGoogleAnalyticsCookie()
            };
        }

        public GoogleAnalyiticsPayload Payload { get; set; }

        protected IHttpContextAccessor HttpContextAccessor { get; set; }
        
        private string GetGoogleAnalyticsCookie()
        {
            var cookie = this.HttpContextAccessor.HttpContext.Request.Cookies["_ga"];
            return cookie == null ? null : string.Join(".", cookie.Split('.').Reverse().Take(2).Reverse());
        }

        public void UpdatePopulator(IDictionary<string, object> properties)
        {
            if (this.Payload.ClientId != null)
            {
                properties.Add("Google Analyitics", this.Payload);
            }
        }
    }
}
