using System;

namespace Spoilt.Models
{
    public class Spoiler
    {
        // Model props:
        public int ID { get; set; }
        public string MovieID { get; set; }
        public string SpoilerText { get; set; }
        public DateTime Created { get; set; }

        // Navigation props:
        public Movie Movie { get; set; }
    }
}
