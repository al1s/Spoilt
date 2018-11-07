using System;
using System.Collections.Generic;

namespace Spoilt.Models
{
    public class UserSession
    {
        // Model props:
        // SessionID created via JS and stored in LocalStorage
        public string ID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation prop
        public ICollection<Vote> Votes { get; set; }
    }
}
