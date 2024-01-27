using Domain.Entities;
using Domain.Identitiy;
using Microsoft.EntityFrameworkCore;

namespace Application.Commons.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Task> Tasks { get; }
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<UserRefreshToken> UserRefreshTokens { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
