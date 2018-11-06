﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spoilt.Models;

namespace Spoilt.Data
{
    public class SpoiltDbContext : IdentityDbContext
    {
        public SpoiltDbContext(DbContextOptions<SpoiltDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Spoiler> Spoilers { get; set; }
    }
}