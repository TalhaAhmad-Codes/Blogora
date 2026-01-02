using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.BlogDTOs
{
    public sealed class BlogDto : AuditableDto
    {
        public int UserId { get; init; }
        public byte[]? FeaturedImage { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
