using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiPageContext.Models;

namespace WikiPageContext.Persistenc;

public class RevisionConfiguration: IEntityTypeConfiguration<Revision> {
    public void Configure(EntityTypeBuilder<Revision> builder) {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).ValueGeneratedNever();
        builder.Property(r => r.Content).IsRequired();

        builder.HasOne(r => r.Article)
            .WithMany(a => a.Revisions)
            .HasForeignKey(r => r.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}