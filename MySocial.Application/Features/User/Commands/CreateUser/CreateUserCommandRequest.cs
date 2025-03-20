namespace MySocial.Application.Features.User.Commands.CreateUser;
public record CreateUserRequest(
    string Name,
    string Email,
    string? Bio = null
);
