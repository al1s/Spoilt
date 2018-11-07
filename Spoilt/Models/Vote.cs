using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models
{
    public class Vote
    {
        // Model props
        public int ID { get; set; }
        public string MovieID { get; set; }
        public int SpoilerID { get; set; }
        public string SessionID { get; set; }

        // Navigation props
        public Session Session { get; set; }
    }
}
