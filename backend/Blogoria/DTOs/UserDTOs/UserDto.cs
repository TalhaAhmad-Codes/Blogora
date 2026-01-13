using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.UserDTOs
{
    public sealed class UserDto : AuditableDto
    {
        public byte[]? ProfilePic { get; init; }
        public string Email { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
