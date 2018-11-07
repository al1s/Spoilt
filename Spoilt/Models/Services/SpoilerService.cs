using Spoilt.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Spoilt.Models.Services
{
    public class SpoilerService : ISpoiler
    {
        public async Task<bool> AddOne(Spoiler spoiler)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://spoiltapi.azurewebsites.net");
                var response = await client.PostAsJsonAsync("/api/spoilers/", spoiler);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<Spoiler> GetSpoiler(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://spoiltapi.azurewebsites.net");
                var response = await client.GetAsync($"/api/spoilers/{id}");
                Spoiler result = new Spoiler();
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<Spoiler>();
                }
                return result;
            }
        }

        public async Task<bool> UpdateOne(int id, Spoiler spoiler)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://spoiltapi.azurewebsites.net");
                var response = await client.PutAsJsonAsync($"/api/spoilers/{id}", spoiler);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
