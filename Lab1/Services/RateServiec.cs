using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbrbAPI.Models;
using System.Net.Http;
using System.Text.Json;

namespace Lab1.Services
{
    public class RateService: IRateService
    {
        private HttpClient client;

        public RateService()
        {
            client = new HttpClient();
        }
        public async Task<IEnumerable<Rate>> GetRates(DateTime date)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://api.nbrb.by/exrates/rates?ondate={date.ToString("yyyy-MM-dd")}&parammode=2");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Rate>>(responseBody);
        }
    }
}
