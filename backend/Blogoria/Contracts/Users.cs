namespace Blogoria.Contracts.Users
{
    // To create a new user
    public sealed record CreateUserRequest(
        string Username,
        string Email,
        string Password
    );

    // To update an existing user's name
    public sealed record UpdateUsernameRequest(
        string Username
    );

    // To update an existing user's email
    public sealed record UpdateEmailRequest(
        string Email,
        string Password
    );

    // To update an existing user's password
    public sealed record UpdatePasswordRequest(
        string OldPassword,
        string NewPassword
    );

    // To get user data
    public sealed record UserResponse(
        int Id,
        string Username,
        string Email,
        DateTime CreatedAt,
        DateTime ? UpdatedAt
    );
}
