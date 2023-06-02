using CookBlog.Core.Abstractions;

namespace CookBlog.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.Now;
}
