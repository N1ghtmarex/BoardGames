using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Lobby> Lobbies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
