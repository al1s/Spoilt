using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models.ViewModels
{
    public class MovieSpoilers
    {
        // Model Properties:
        public Movie Movie { get; set; }

        // Collection of spoilers that belong to a particular movie
        public ICollection<Spoiler> Spoilers { get; set; }
    }
}
