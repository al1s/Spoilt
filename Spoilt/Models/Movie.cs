﻿using System.Collections.Generic;

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
        public string Poster { get; set; }

        // Navigation properties
        public ICollection<Spoiler> Spoilers { get; set; }
    }
}
