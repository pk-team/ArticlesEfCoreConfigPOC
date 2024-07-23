using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WikiPageContext.Persistenc;

public class DbContextFactory: IDesignTimeDbContextFactory<AppDbContext> {
    public AppDbContext CreateDbContext(string[] args) {
        var connectionString = "server=localhost,9301;database=articles;uid=sa;pwd=DevDevDude119#;Encrypt=false;";

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new AppDbContext(options);
    }
}