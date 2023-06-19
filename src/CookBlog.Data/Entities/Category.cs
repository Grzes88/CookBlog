using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Entities;

public class Category
{
    public CategoryId Id { get; }
    public FullName FullName { get; private set; }
    public IEnumerable<Post> Posts => _posts;

    private readonly HashSet<Post> _posts = new HashSet<Post>();

    public Category()
    {
    }

    public Category(CategoryId id, FullName fullName)
    {
        Id = id;
        FullName = fullName;
    }

    public static Category Create(CategoryId id, FullName fullName) => new Category(id, fullName);
}
