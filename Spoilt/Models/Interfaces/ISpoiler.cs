using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface ISpoiler : IServiceProvider
    {
        // Get Spoilers by MovieId
        Task<IEnumerable<Spoiler>> GetSpoilers(string movieId);

        // Add a Spoiler
        Task<Spoiler> AddOne(Spoiler spoiler);
    }
}
