namespace CookBlog.Core.Entities;

public class Comment
{
    public Guid Id { get; }
    public string FullName { get; }
    public string Description { get; }

    public Comment()
    {
    }

    public Comment(Guid id, string fullName, string description)
    {
        Id = id;
        FullName = fullName;
        Description = description;
    }
}
