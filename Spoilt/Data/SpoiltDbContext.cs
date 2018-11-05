using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Spoilt.Data
{
    public class SpoiltDbContext : IdentityDbContext
    {
        public SpoiltDbContext(DbContextOptions<SpoiltDbContext> options)
            : base(options)
        {
        }
    }
}
