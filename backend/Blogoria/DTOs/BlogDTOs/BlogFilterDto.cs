using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.BlogDTOs
{
    public sealed class BlogFilterDto : BaseFilterDto
    {
        public int? AuthorId { get; init; }
        public int? ReactionOfUserId { get; init; }
        public int? CommentOfUserId { get; init; }
        public int? MinReactionsCount { get; init; }
        public int? MaxReactionsCount { get; init; }
        public int? MinCommentsCount { get; init; }
        public int? MaxCommentsCount { get; init; }
    }
}
