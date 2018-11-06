using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models
{
    public class Session
    {
        // Model props:
        // SessionID created via JS and stored in LocalStorage
        public string ID { get; set; }
        public DateTime CreatedAt { get => DateTime.Now; }

        // Navigation prop
        public ICollection<Vote> Votes { get; set; }
    }
}
