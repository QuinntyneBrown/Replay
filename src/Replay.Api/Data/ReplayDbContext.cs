using Replay.Api.Models;
using Replay.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Replay.Api.Data
{
    public class ReplayDbContext: DbContext, IReplayDbContext
    {
        public DbSet<ToDo> ToDos { get; private set; }
        public ReplayDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReplayDbContext).Assembly);
        }
        
    }
}
