using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Entities;

public class Category
{
    public CategoryId Id { get; }
    public FullName FullName { get; private set; }

    public Category()
    {     
    }

    public Category(CategoryId id, FullName fullName)
    {
        Id = id;
        FullName = fullName;
    }
}
