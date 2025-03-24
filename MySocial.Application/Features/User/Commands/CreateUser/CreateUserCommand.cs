using MediatR;

namespace MySocial.Application.Features.User.Commands.CreateUser;
public record CreateUserCommand(
    string Name,
    string Email,
    string? Bio = null
    ) : IRequest<CreateUserCommandResponse>;
