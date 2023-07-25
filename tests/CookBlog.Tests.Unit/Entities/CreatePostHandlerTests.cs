﻿using CookBlog.Application.Commands;
using CookBlog.Application.Commands.Handlers;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;
using FluentAssertions;
using Moq;
using Xunit;

namespace CookBlog.Tests.Unit.Entities;

public class CreatePostHandlerTests
{
    private readonly CreatePostHandler _createPostHandler;
    private readonly Mock<ITagRepository> _tagRepoMock = new Mock<ITagRepository>();
    private readonly Mock<IPostRepository> _postRepoMock = new Mock<IPostRepository>();

    public CreatePostHandlerTests()
    {
        _createPostHandler = new CreatePostHandler(_postRepoMock.Object, _tagRepoMock.Object);
    }

    [Fact]
    public void Should_Create_Post()
    {
        //Arrange
        var createPost = new CreatePost("Cake", "It's delicious",
            new CategoryId(Guid.NewGuid()), new UserId(Guid.NewGuid()), new HashSet<Guid>());
        _postRepoMock.Setup(x => x.AddAsync(It.IsAny<Post>()));

        //Act
        var result = _createPostHandler.HandleAsync(createPost);

        //Assert
        result.Should().NotBeNull();
        _postRepoMock.Verify(x => x.AddAsync(It.IsAny<Post>()), Times.Exactly(1));
    }
}