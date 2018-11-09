using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface IUserSession
    {
        Task CreateSessionString(string localStorageString);
    }
}
