using Microsoft.EntityFrameworkCore;


namespace RandomFacts.Api.Models
{
    public class DocContext : DbContext
    {
        public DocContext(DbContextOptions<DocContext> options) : base(options) { }

       // Had a lot of sql connection here. But didn't work, so cleaned up instead. Tried as example at Github 

        public DbSet<Doc> DocItems { get; set; }

    }


}