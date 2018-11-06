﻿using Spoilt.Models.Interfaces;
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

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            using (HttpClient client = new HttpClient())
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
        }

        public async Task<IEnumerable<Movie>> GetMoviesByTitle(string title)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://spoiltapi.azurewebsites.net");
                var response = await client.GetAsync($"/api/movies/search?term={title}");
                List<Movie> result = new List<Movie>();
                if (response.IsSuccessStatusCode)
                {
                    var omdbResult = await response.Content.ReadAsAsync<OMDB>();
                    foreach(var movieResult in omdbResult.Search)
                    {
                        Movie movie = new Movie();
                        movie.ID = movieResult.ImdbID;
                        movie.Title = movieResult.Title;
                        movie.PosterUrl = movieResult.Poster;
                        result.Add(movie);
                    }
                }
                return result;
            }
        }

        public Task<Movie> GetMovieById(string id)
        {
            throw new NotImplementedException();
        }
    }
}