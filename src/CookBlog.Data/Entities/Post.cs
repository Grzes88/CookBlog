using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Entities;

public class Post
{
    public PostId Id { get; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Category Category { get; private set; }
    public CategoryId CategoryId { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }
    public IEnumerable<Tag> Tags => _tags;
    public IEnumerable<Comment> Comments => _comments;

    private readonly HashSet<Tag> _tags = new HashSet<Tag>();
    private readonly HashSet<Comment> _comments = new HashSet<Comment>();

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
