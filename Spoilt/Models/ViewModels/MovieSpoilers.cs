using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models.ViewModels
{
    public class MovieSpoilers
    {
        // Model Properties:
        public string MovieID { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string PosterUrl { get; set; }

        public ICollection<Spoiler> Spoilers { get; set; }
    }
}
