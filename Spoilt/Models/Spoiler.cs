﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoilt.Models
{
    public class Spoiler
    {
        // Model props:
        public int ID { get; set; }
        public string MovieID { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        // Navigation props:
        public Movie Movie { get; set; }
    }
}
