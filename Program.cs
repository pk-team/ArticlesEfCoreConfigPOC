// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

using WikiPageContext.Models;
using WikiPageContext.Persistenc;

Console.WriteLine("Hello, World!");

var connectionString = "server=localhost,9301;database=articles;uid=sa;pwd=DevDevDude119#;Encrypt=false;";

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .Options;

using(var ctx = new AppDbContext(options)) {
    ctx.Database.EnsureDeleted();
    ctx.Database.Migrate();
};

using(var ctx = new AppDbContext(options)) {
    var article = Article.Create("Hello, World!");
    ctx.Articles.Add(article);
    ctx.SaveChanges();
}
using(var ctx = new AppDbContext(options)) {
    var article = ctx.Articles.Include(t => t.Revisions).First();
    article.Update("Hello, World! 2");
    ctx.SaveChanges();
}
using(var ctx = new AppDbContext(options)) {
    var article = ctx.Articles.Include(t => t.Revisions).First();
    Console.WriteLine(article.Content);
    foreach(var revision in article.Revisions) {
        Console.WriteLine(revision.Content);
        Console.WriteLine(revision.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
using(var ctx = new AppDbContext(options)) {
    var article = ctx.Articles.Include(t => t.Revisions).First();
    article.Update("Hello, World! 3");
    ctx.SaveChanges();
}
using(var ctx = new AppDbContext(options)) {
    var article = ctx.Articles.Include(t => t.Revisions).First();
    Console.WriteLine(article.Content);
    Console.WriteLine($"Revision count: {article.Revisions.Count}");
    foreach(var revision in article.Revisions) {
        Console.WriteLine(revision.Content);
        Console.WriteLine(revision.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}



