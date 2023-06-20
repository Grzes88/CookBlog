using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Entities;

public class Tag
{
    public TagId Id { get; }
    public Description Description { get; private set; }
    public IEnumerable<Post> Posts => _posts;

    private readonly HashSet<Post> _posts = new HashSet<Post>();

    public Tag()
    {
    }

    public Tag(TagId id, Description description)
    {
        Id = id;
        Description = description;
    }
}
