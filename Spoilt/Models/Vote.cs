using System;

namespace Spoilt.Models
{
    public class Vote
    {
        // Model props
        public int ID { get; set; }
        public string MovieID { get; set; }
        public int SpoilerID { get; set; }
        public string UserSessionID { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation props
        public UserSession Session { get; set; }
    }
}
