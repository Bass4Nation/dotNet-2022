using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RandomFacts.Api.Models
{
    public class FactContext : DbContext
    {
        public FactContext(DbContextOptions<FactContext> options)
            : base(options)
        {
        }

        public DbSet<Fact> FactItems { get; set; }
    }
}
