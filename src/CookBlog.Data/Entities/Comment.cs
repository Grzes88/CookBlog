using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Entities;

public class Comment
{
    public CommentId Id { get; }
    public FullName FullName { get; private set; }
    public Description Description { get; private set; }
    public PostId PostId { get; private set; }
    public Post Post { get; private set; }

    public Comment()
    {
    }

    public Comment(CommentId id, FullName fullName, Description description)
    {
        Id = id;
        FullName = fullName;
        Description = description;
    }
}
