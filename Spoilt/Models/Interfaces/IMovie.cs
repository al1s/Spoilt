using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface IMovie : IServiceProvider
    {
        // Get All
        Task<IEnumerable<Movie>> GetMovies();

        // Get Movies by Title
        Task<IEnumerable<Movie>> GetMoviesByTitle(string title);

        // Get One
        Task<Movie> GetMovieById(string id);
    }
}
