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
            //if (!(Connectivity.Current.NetworkAccess==NetworkAccess.None))
            //{
            //    throw new Exception("No internet connection");
            //}

            var client = new HttpClient();
            var response = await client.GetAsync($"https://api.nbrb.by/exrates/rates?ondate={date.ToString("yyyy-MM-dd")}&periodicity=0");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Rate>>(responseBody);
        }
    }
}
