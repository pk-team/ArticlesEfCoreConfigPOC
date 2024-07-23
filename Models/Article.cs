namespace WikiPageContext.Models;

public class Article {
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Content { get; private set; } = null!;
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; private set; }
    public List<Revision> Revisions { get; set; } = [];

    public static Article Create(string content) {
        var article =  new Article {
            Content = content,
            UpdatedAt = DateTimeOffset.UtcNow
        };
        return article;
    }

    public void Update(string content) {
        Revisions.Add(Revision.Create(Content, UpdatedAt));
        Content = content;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    private Article() {
        // Required for EF
    }
}
