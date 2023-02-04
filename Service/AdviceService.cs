using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdviceEmulator.Service
{
    public class AdviceService : IAdviceService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri;
        public AdviceService()
        {
            _httpClient = new HttpClient();
            _baseUri = "https://api.adviceslip.com/advice";

        }

        public async Task<HttpResponseMessage> GetDailyAdvie()
        {
            var response = await _httpClient.GetAsync(_baseUri);
            return response;



        }

    }
}
