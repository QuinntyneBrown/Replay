using Replay.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Replay.Api.Interfaces
{
    public interface IReplayDbContext
    {
        DbSet<ToDo> ToDos { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
