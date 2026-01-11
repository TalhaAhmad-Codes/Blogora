using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.UserCommentDTOs
{
    public sealed class UserCommentDto : AuditableDto
    {
        public int UserId { get; init; }
        public int BlogId { get; init; }
        public string Comment { get; init; }
    }
}
