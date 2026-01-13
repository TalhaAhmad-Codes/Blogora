using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.DTOs.UserCommentDTOs.UserCommentUpdateDtos;
using Blogoria.Mappers;
using Blogoria.Misc;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Blogoria.Services.Interfaces;

namespace Blogoria.Services
{
    public sealed class UserCommentService : IUserCommentService
    {
        private readonly IUserCommentRepository _repository;

        public UserCommentService(IUserCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserCommentDto> AddUserCommentAsync(AddUserCommentDto userCommentDto)
        {
            // Check if user and blog exist
            var userId = userCommentDto.UserId; var blogId = userCommentDto.BlogId;

            if (userId > 0)
            {
                if (!await _repository.UserExists(userId))
                    throw new DomainException($"User of id {userId} doesn't exist.");
            }

            if (blogId > 0)
            {
                if (!await _repository.BlogExists(blogId))
                    throw new DomainException($"Blog of id {blogId} doesn't exist.");
            }

            // Add user comment
            var userComment = UserComment.Create(
                userId: userId,
                blogId: blogId,
                comment: userCommentDto.Comment
            );

            await _repository.AddAsync(userComment);

            return UserCommentMapper.ToDto(userComment);
        }

        public async Task<PagedResultDto<UserCommentDto>> GetAllAsync(UserCommentFilterDto filterDto)
        {
            var result = await _repository.GetAllAsync(filterDto);

            return new PagedResultDto<UserCommentDto> 
            {
                Items = result.Items.Select(UserCommentMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<UserCommentDto?> GetByIdAsync(int id)
        {
            var userComment = await _repository.GetByIdAsync(id);

            return (userComment is null) ? null : UserCommentMapper.ToDto(userComment);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var userComment = await _repository.GetByIdAsync(id);

            if (userComment is null) return false;

            await _repository.RemoveAsync(userComment);
            return true;
        }

        public async Task<bool> UpdateUserCommentAsync(UserCommentUpdateCommentDto dto)
        {
            var userComment = await _repository.GetByIdAsync(dto.Id);

            if (userComment is null) return false;

            userComment.UpdateComment(dto.Comment);
            await _repository.UpdateAsync(userComment);
            return true;
        }
    }
}
