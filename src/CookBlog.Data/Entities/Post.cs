using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Entities;

public class Post
{
    public PostId Id { get; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }

    public Post()
    {
    }

    public Post(PostId id, Title title, Description description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
}
