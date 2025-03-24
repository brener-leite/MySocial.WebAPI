using MediatR;
using MySocial.Domain.Exceptions;
using MySocial.Domain.Interfaces;
using UserEntity = MySocial.Domain.Entities.User;

namespace MySocial.Application.Features.User.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var isEmailUnique = await _userRepository.IsEmailUniqueAsync(request.Email);
        if (!isEmailUnique)
        {
            throw new ConflictException("Email already exists");
        }

        var user = new UserEntity(request.Name, request.Email, request.Bio);
        await _userRepository.AddAsync(user);

        return new CreateUserCommandResponse(user.Name, user.Email);
    }
}