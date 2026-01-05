using Blogoria.Contracts.Common;
using Blogoria.Contracts.Users;
using Blogoria.Misc.Exceptions;
using Blogoria.Models.Entities;
using Blogoria.Models.ValueObjects;
using Blogoria.Repositories.Interfaces;
using Blogoria.Services.Interfaces;

namespace Blogoria.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> CreateAsync(CreateUserRequest request)
        {
            if (await _userRepository.ExistsByEmailAsync(request.Email))
                throw new EmailAlreadyExistsException("Email already in use.");

            var user = User.Create(
                profilePic: null,
                email: Email.Create(request.Email),
                username: request.Username,
                password: request.Password
            );

            await _userRepository.AddAsync(user);

            return MapToResponse(user);
        }

        public async Task<UserResponse?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user is null ? null : MapToResponse(user);
        }

        public async Task<UserResponse?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return user is null ? null : MapToResponse(user);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
            => await _userRepository.ExistsByEmailAsync(email);

        public async Task<PagedResponse<UserResponse>> GetPagedAsync(PagedRequest request)
        {
            // NOTE: This is intentionally service-driven pagination
            // In high-scale apps, this would move to a query repository
            var page = request.Page <= 0 ? 1 : request.Page;
            var pageSize = request.PageSize <= 0 ? 10 : request.PageSize;

            // naive approach (fine for portfolio)
            var users = await _userRepository.GetAllAsync();
            var total = users.Count();

            var items = users
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(MapToResponse)
                .ToList();

            return new PagedResponse<UserResponse>(
                items,
                total,
                page,
                pageSize
            );
        }

        public async Task<bool> UpdateUsernameAsync(int userId, UpdateUsernameRequest request)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                return false;

            user.UpdateUsername(request.Username);

            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdateEmailAsync(int userId, UpdateEmailRequest request)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                return false;

            try
            {
                user.UpdateEmail(request.Password, request.Email);
            }
            catch (InvalidCredentialsException)
            {
                return false;
            }

            await _userRepository.UpdateAsync(user);
            return true;
        }
        
        public async Task<bool> UpdatePasswordAsync(int userId, UpdatePasswordRequest request)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                return false;

            try
            {
                user.UpdatePassword(request.OldPassword, request.NewPassword);
            }
            catch (InvalidCredentialsException)
            {
                return false;
            }

            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> RemoveAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                return false;

            await _userRepository.RemoveAsync(user);
            return true;
        }

        private static UserResponse MapToResponse(User user)
            => new(
                Id: user.Id,
                Username: user.Username,
                Email: user.Email.Value,
                CreatedAt: user.CreatedAt,
                UpdatedAt: user.UpdatedAt
            );
    }
}
