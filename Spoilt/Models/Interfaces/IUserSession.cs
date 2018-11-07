using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface IUserSession : IServiceProvider
    {
        Task<UserSession> CreateSessionString();
    }
}
