using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models
{
    public class OMDB
    {
        public string Name { get; set; }

        public IEnumerable<MovieSearchDescription> Search { get; set; }

        public bool Response { get; set; }
        
        public int TotalResults { get; set; }

        public string Error { get; set; }
    }

    public class MovieSearchDescription
    {
        public string Title { get; set; }

        public string Year { get; set; }
        
        public string ImdbID { get; set; }

        public string Type { get; set; }

        public string Poster { get; set; }
    }
}
