using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserDTOs;
using Blogoria.DTOs.UserDTOs.UserUpdateDtos;
using Blogoria.Mappers;
using Blogoria.Misc;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Blogoria.Services.Interfaces;

namespace Blogoria.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto userDto)
        {
            // Esures that email must be new and not already registered
            if (await _repository.ExistsByEmailAsync(userDto.Email))
                throw new DomainException("A user already exists with that email.");

            var user = User.Create(
                profilePic: null,
                email: userDto.Email,
                username: userDto.Username,
                password: userDto.Password
            );

            await _repository.AddAsync(user);

            return UserMapper.ToDto(user);
        }

        public async Task<PagedResultDto<UserDto>> GetAllAsync(UserFilterDto filterDto)
        {
            var result = await _repository.GetAllAsync(filterDto);

            return new PagedResultDto<UserDto>
            {
                Items = result.Items.Select(UserMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return (user is null) ? null : UserMapper.ToDto(user);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null) return false;

            await _repository.RemoveAsync(user);
            return true;
        }

        public async Task<bool> UpdateEmailAsync(UserUpdateEmailDto dto)
        {
            var user = await _repository.GetByIdAsync(dto.Id);

            if (user is null) return false;
                
            user.UpdateEmail(dto.Password, dto.Email);
            await _repository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdatePasswordAsync(UserUpdatePasswordDto dto)
        {
            var user = await _repository.GetByIdAsync(dto.Id);

            if (user is null) return false;

            // User must confirm new password
            if (dto.NewPassword != dto.ConfirmPassword)
                throw new DomainException("Password didn't match.");

            user.UpdatePassword(dto.OldPassword, dto.NewPassword);
            await _repository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdateProfilePicAsync(UserUpdateProfilePicDto dto)
        {
            var user = await _repository.GetByIdAsync(dto.Id);

            if (user is null) return false;

            user.UpdateProfilePic(dto.ProfilepPic);
            await _repository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdateUsernameAsync(UserUpdateUsernameDto dto)
        {
            var user = await _repository.GetByIdAsync(dto.Id);

            if (user is null) return false;

            user.UpdateUsername(dto.Username);
            await _repository.UpdateAsync(user);
            return true;
        }
    }
}
