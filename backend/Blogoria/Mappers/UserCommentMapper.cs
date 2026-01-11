using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Mappers
{
    public static class UserCommentMapper
    {
        public static UserCommentDto ToDto(UserComment userComment)
            => new() {
                Id = userComment.Id,
                BlogId = userComment.BlogId,
                UserId = userComment.UserId,
                Comment = userComment.Comment,
                CreatedAt = userComment.CreatedAt,
                UpdatedAt = userComment.UpdatedAt
            };
    }
}
