namespace CookBlog.Core.Entities;

public class Category
{
    public Guid Id { get; }
    public string Name { get; }

    public Category()
    {     
    }

    public Category(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
