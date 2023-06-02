using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Entities;

public class Post
{
    public PostId Id { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public Post()
    {
    }

    public Post(PostId id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
}
