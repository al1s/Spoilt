using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models
{
    public class Movie
    {
        // Model Properties:
        // Grab from IMDB string ID for movie
        public string ID { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string PosterUrl { get; set; }

        // Navigation properties
        public ICollection<Spoiler> Spoilers { get; set; }
    }
}
