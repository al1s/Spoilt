using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface ISpoiler
    {
        // Add a Spoiler
        Task<bool> AddOne(Spoiler spoiler);

        // Get one Spoiler
        Task<Spoiler> GetSpoiler(int id);

        // Update a Spoiler
        Task<bool> UpdateOne(int id, Spoiler spoiler);
    }
}
