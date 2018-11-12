using Spoilt.Data;
using Spoilt.Models.Interfaces;
using System.Linq;
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

        public async Task CreateSessionString(string localStorageString)
        {
            if (_context.Sessions.FirstOrDefault(s => s.ID == localStorageString) == null)
            {
                UserSession session = new UserSession
                {
                    ID = localStorageString
                };

                _context.Sessions.Add(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}
