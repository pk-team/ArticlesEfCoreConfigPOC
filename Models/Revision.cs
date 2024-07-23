namespace WikiPageContext.Models;

public class Revision {
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Content { get; init; } = null!;
    public DateTimeOffset CreatedAt { get; init; }

    public Article Article { get; set; } = null!;
    public string ArticleId { get; init; } = null!;

    public static Revision Create(string content, DateTimeOffset articleCreatedAt) {
        var pageRevision = new Revision {
            Content = content,
            CreatedAt = articleCreatedAt
        };
        return pageRevision;
    }
}



