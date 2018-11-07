using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spoilt.Models.Interfaces;
using Spoilt.Models;
using Spoilt.Data;

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
