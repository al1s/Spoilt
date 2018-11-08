using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface IUserSession
    {
        Task<UserSession> CreateSessionString(string localStorageString);
    }
}
