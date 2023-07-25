using CookBlog.Application.Commands;
using CookBlog.Application.Commands.Handlers;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using FluentAssertions;
using Moq;
using Xunit;

namespace CookBlog.Tests.Unit.Entities;

public class CreateTagHandlerTests
{

    private readonly CreateTagHandler _createTagHandler;
    private readonly Mock<ITagRepository> _tagRepoMok = new Mock<ITagRepository>();

    public CreateTagHandlerTests()
    {
        _createTagHandler = new CreateTagHandler(_tagRepoMok.Object);
    }

    [Fact]
    public void Handle_Should_Create_Tag()
    {
        //Arrange
        var createTag = new CreateTag(new Description("słabe"));

        //Act
        var result = _createTagHandler.HandleAsync(createTag);

        //Assert
        result.Should().NotBeNull();
        _tagRepoMok.Verify(x => x.AddAsync(It.IsAny<Tag>()), Times.Exactly(1));
    }
}
