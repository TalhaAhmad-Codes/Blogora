using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.UserCommentDTOs
{
    public sealed class UserCommentFilterDto : BaseFilterDto
    {
        public int? UserId { get; init; }
        public int? BlogId { get; init; }
    }
}
