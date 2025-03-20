namespace MySocial.Application.Features.User.Commands.CreateUser;
public record UserCreatedResponse(
    Guid Id,
    string Name,
    string Email
);
