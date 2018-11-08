using Spoilt.Data;
using Spoilt.Models.Interfaces;
using System.Threading.Tasks;

namespace Spoilt.Models.Services
{
    public class UserSessionService : IUserSession
    {
        private SpoiltDbContext _context;

        public UserSessionService(SpoiltDbContext context)
        {
            _context = context;
        }

        public async Task<UserSession> CreateSessionString(string localStorageString)
        {
            UserSession session = new UserSession
            {
                ID = localStorageString
            };
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            return session;
        }
    }
}
