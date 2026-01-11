using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.UserDTOs.UserUpdateDtos
{
    public sealed class UserUpdateProfilePicDto : BaseDto
    {
        public byte[]? ProfilepPic { get; init; }
    }
    
    public sealed class UserUpdateUsernameDto : BaseDto
    {
        public string Username { get; init; }
    }

    public sealed class UserUpdateEmailDto : BaseDto
    {
        public string Password { get; init; }
        public string Email { get; init; }
    }

    public sealed class UserUpdatePasswordDto : BaseDto
    {
        public string OldPassword { get; init; }
        public string NewPassword { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
