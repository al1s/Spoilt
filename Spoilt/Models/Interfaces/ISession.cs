using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    public interface ISession
    {
        Task<Session> CreateSessionString();
    }
}
