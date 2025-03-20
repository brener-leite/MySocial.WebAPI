using MediatR;
using MySocial.Domain.Interfaces;
using UserEntity = MySocial.Domain.Entities.User;

namespace MySocial.Application.Features.User.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserEntity(
            request.Name,
            request.Email,
            request.Bio
        );

        await _userRepository.AddAsync(user);
        return user.Id;
    }
}