using LinkedOff.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.Data
{
    public class LinkedContext : IdentityDbContext<LinkedUser>
    {
        public LinkedContext(DbContextOptions<LinkedContext> options) : base(options)
        {
        }


        public DbSet<StatusUpdate> StatusUpdates { get; set; }
        public DbSet<Experience> Experiences { get; set; }

    }
}
