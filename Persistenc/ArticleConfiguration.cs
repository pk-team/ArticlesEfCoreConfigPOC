using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiPageContext.Models;

namespace WikiPageContext.Persistenc;

public class ArticleConfiguration: IEntityTypeConfiguration<Article> {
    public void Configure(EntityTypeBuilder<Article> builder) {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.Property(a => a.Content).IsRequired();

        builder.HasMany(a => a.Revisions)
            .WithOne()
            .HasForeignKey(r => r.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}