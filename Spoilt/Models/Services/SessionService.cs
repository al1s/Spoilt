using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spoilt.Models.Interfaces;

namespace Spoilt.Models.Services
{
    public class SessionService : ISession
    {
        Task<Session> ISession.CreateSessionString()
        {
            throw new NotImplementedException();
        }
    }
}
