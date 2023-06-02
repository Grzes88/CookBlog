namespace CookBlog.Core.Entities;

public class Tag
{
    public Guid Id { get; }
    public string Description { get; }

    public Tag()
    {
    }

    public Tag(Guid id, string description)
    {
        Id = id;
        Description = description;
    }
}
