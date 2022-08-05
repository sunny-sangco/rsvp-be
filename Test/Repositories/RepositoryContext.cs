using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public virtual DbSet<RSVP> RSVP { get; set; }
    }
}
