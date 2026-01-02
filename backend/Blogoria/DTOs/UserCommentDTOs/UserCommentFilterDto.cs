using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.UserCommentDTOs
{
    public class UserCommentFilterDto : BaseFilterDto
    {
        public int? UserId { get; init; }
    }
}
