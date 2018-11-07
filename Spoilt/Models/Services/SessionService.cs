using Spoilt.Data;
using Spoilt.Models.Interfaces;
using System.Threading.Tasks;

namespace Spoilt.Models.Services
{
    public class SessionService : ISession
    {
        private SpoiltDbContext _context;

        public SessionService(SpoiltDbContext context)
        {
            _context = context;
        }

        public async Task<Session> CreateSessionString()
        {
            Session session = new Session();
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            return session;
        }
    }
}
