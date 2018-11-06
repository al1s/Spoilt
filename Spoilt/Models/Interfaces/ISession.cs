using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models.Interfaces
{
    interface ISession
    {
        Task<Session> CreateSessionString();
    }
}
