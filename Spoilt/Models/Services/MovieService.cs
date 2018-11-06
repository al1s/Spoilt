using Spoilt.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Spoilt.Models.Services
{
    public class MovieService : IMovie
    {
        public static HttpClient client = new HttpClient();

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            client.BaseAddress = new Uri("https://spoiltapi.azurewebsites.net");
            var response = await client.GetAsync("/api/movies");
            Movie defaultMovie = new Movie { Title = "No Movies To Display!" };
            IEnumerable<Movie> result = new List<Movie> { defaultMovie };
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<IEnumerable<Movie>>();
            }
            return result;
        }

        public Task<IEnumerable<Movie>> GetMoviesByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
