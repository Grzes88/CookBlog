using CookBlog.Application.Queries;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Infrastructure.DAL.Handlers;
using FluentAssertions;
using Moq;
using Xunit;

namespace CookBlog.Tests.Unit.Entities;

public class GetCategoriesHandlerTests
{
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock = new Mock<ICategoryRepository>();

    public GetCategoriesHandlerTests()
    {
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
    }

    [Fact]
    public async Task Handle_Should_Return_All_Categories()
    {
        //Arrange
        var categories = new List<Category>();
        var get = new GetCategories();
        var getHandler = new GetCategoriesHandler(_categoryRepositoryMock.Object);
        _categoryRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(categories);

        //Act
        var result = await getHandler.HandleAsync(get);

        //Assert
        result.Should().NotBeNull();
        _categoryRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
    }
}
