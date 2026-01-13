namespace Blogoria.DTOs.UserDTOs
{
    public sealed class CreateUserDto
    {
        public string Email { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
