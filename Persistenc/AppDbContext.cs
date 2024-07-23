using Microsoft.EntityFrameworkCore;

using WikiPageContext.Models;

namespace WikiPageContext.Persistenc;

public class AppDbContext: DbContext {

    public DbSet<Article> Articles { get; set; } = null!;
    public DbSet<Revision> Revisions { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}