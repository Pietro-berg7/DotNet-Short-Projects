using DDD_Model.Domain.Entities;
using DDD_Model.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DDD_Model.Infra.Data.Context;
public class SqlServerContext: DbContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(new UserMap().Configure);
    }
}
