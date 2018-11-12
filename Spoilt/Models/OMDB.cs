using System.Collections.Generic;

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
        public string Plot { get; set; }
        public string Genre { get; set; }

    }
}
