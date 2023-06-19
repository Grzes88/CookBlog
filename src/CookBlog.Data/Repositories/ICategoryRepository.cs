using CookBlog.Core.Entities;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Core.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetAsync(CategoryId id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(CategoryId id);
}
