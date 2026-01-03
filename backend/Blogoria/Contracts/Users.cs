namespace Blogoria.Contracts.Users
{
    // To create a new user
    public sealed record CreateUserRequest(
        string Username,
        string Email,
        string Password
    );

    // To Update an existing user data
    public sealed record UpdateUserRequest(
        string Username,
        string Email,
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
