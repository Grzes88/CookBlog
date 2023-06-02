using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Entities;

public class Tag
{
    public TagId Id { get; }
    public Description Description { get; private set; }

    public Tag()
    {
    }

    public Tag(TagId id, Description description)
    {
        Id = id;
        Description = description;
    }
}
