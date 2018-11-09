using System;
using System.ComponentModel.DataAnnotations;

namespace Spoilt.Models
{
    public class Spoiler
    {
        // Model props:
        public int ID { get; set; }
        public string MovieID { get; set; }
        [Required(ErrorMessage = "That's not a very good spoiler.")]
        public string SpoilerText { get; set; }
        public DateTime Created { get; set; }

        // Navigation props:
        public Movie Movie { get; set; }
        public int Votes { get; set; }
    }
}
