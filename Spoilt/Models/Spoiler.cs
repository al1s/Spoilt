﻿using System;
using System.Collections.Generic;

namespace Spoilt.Models
{
    public class Spoiler
    {
        // Model props:
        public int ID { get; set; }
        public string MovieID { get; set; }
        public string SpoilerText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation props:
        public Movie Movie { get; set; }
        public int Votes { get; set; }
    }
}
