namespace SegmentDotNet.Client
{
    using Configuration;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Request;
    using Request.Abstract;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class SegmentClient
    {
        public SegmentClient(IOptions<SegmentConfiguration> configuration)
        {
            this.Configuration = configuration.Value;
        }

        protected const string URL = "https://api.segment.io/v1/";

        protected SegmentConfiguration Configuration { get; set; }

        public async Task Alias(Alias alias)
        {
            await this.Post(alias);
        }

        public async Task Batch(Batch batch)
        {
            await this.Post(batch);
        }

        public async Task Identify(Identify identify)
        {
            await this.Post(identify);
        }

        public async Task Group(Group group)
        {
            await this.Post(group);
        }

        public async Task Screen(Screen screen)
        {
            await this.Post(screen);
        }

        public async Task Page(Page page)
        {
            await this.Post(page);
        }

        public async Task Track(Track track)
        {
            await this.Post(track);
        }

        public async Task Post(Base baseClass)
        {
            var json = this.Serialize(baseClass);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {this.GetWriteKey()}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync($"{URL}{baseClass.Endpoint}", new StringContent(json, Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public string Serialize(Base baseClass)
        {
            return JsonConvert.SerializeObject(baseClass);
        }

        public string GetWriteKey()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(this.Configuration.WriteKey + ":"));
        }
    }
}
