using Blogoria.DTOs.UserDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
            => new() {
                Id = user.Id,
                ProfilePic = user.ProfilePic,
                Username = user.Username,
                Email = user.Email.Value,
                Password = user.PasswordHash,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
    }
}
