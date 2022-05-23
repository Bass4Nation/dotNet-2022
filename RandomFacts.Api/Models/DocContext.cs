using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RandomFacts.Api.Models
{
    public class DocContext : DbContext
    {
        public DocContext(DbContextOptions<DocContext> options)
            : base(options)
        {
        }

        public DbSet<Doc> DocItems { get; set; }
    }
}