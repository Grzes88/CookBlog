using CookBlog.Application.Abstractions;
using CookBlog.Application.Exceptions;
using CookBlog.Application.Security;
using CookBlog.Core.Abstractions;
using CookBlog.Core.Entities;
using CookBlog.Core.Repositories;
using CookBlog.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;

    public SignUpHandler(IUserRepository userRepository,
        IPasswordManager passwordManager, IClock clock)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _clock = clock;
    }

    public async Task HandleAsync(SignUp command)
    {
        var userId = new UserId(command.UserId);
        var email = new Email(command.Email);
        var userName = new UserName(command.UserName);
        var password = new Password(command.Password);
        var fullName = new FullName(command.FullName);
        var role = string.IsNullOrWhiteSpace(command.Role) ? Role.User() : new Role(command.Role);

        if (await _userRepository.GetByEmailAsync(email) is not null)
            throw new EmailAlreadyInUseException(email);

        if (await _userRepository.GetByUserNameAsync(userName) is not null)
            throw new UserNameAlreadyInUseException(userName);

        var securedPassword = _passwordManager.Secure(password);
        var user = new User(userId, email, userName, securedPassword, fullName, role, _clock.Current());
        await _userRepository.AddAsync(user);
    }
}