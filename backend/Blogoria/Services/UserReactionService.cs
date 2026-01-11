using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserReactionDTOs;
using Blogoria.DTOs.UserReactionDTOs.UserReactionUpdateDtos;
using Blogoria.Mappers;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Blogoria.Services.Interfaces;

namespace Blogoria.Services
{
    public sealed class UserReactionService : IUserReactionService
    {
        private readonly IUserReactionRepository _repository;

        public UserReactionService(IUserReactionRepository repository)
        {
            _repository = repository; 
        }

        public async Task<UserReactionDto> AddUserReaction(UserReactionDto userReactionDto)
        {
            var userReaction = UserReaction.Create(
                userId: userReactionDto.UserId,
                blogId: userReactionDto.BlogId,
                reactionType: userReactionDto.ReactionType
            );

            await _repository.AddAsync(userReaction);
            return userReactionDto;
        }

        public async Task<PagedResultDto<UserReactionDto>> GetAllAsync(UserReactionFilterDto filterDto)
        {
            var result = await _repository.GetAllAsync(filterDto);

            return new PagedResultDto<UserReactionDto>
            {
                Items = result.Items.Select(UserReactionMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<UserReactionDto?> GetByIdAsync(int id)
        {
            var userReaction = await _repository.GetByIdAsync(id);

            return (userReaction is null) ? null : UserReactionMapper.ToDto(userReaction);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var userReaction = await _repository.GetByIdAsync(id);

            if (userReaction is null) return false;

            await _repository.RemoveAsync(userReaction);
            return true;
        }

        public async Task<bool> UpdateUserReactionAsync(UserReactionUpdateReactionDto dto)
        {
            var userReaction = await _repository.GetByIdAsync(dto.Id);

            if (userReaction is null) return false;

            userReaction.UpdateReactionType(dto.ReactionType);
            await _repository.UpdateAsync(userReaction);
            return true;
        }
    }
}
