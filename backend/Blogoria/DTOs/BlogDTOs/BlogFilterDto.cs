using Blogoria.DTOs.Common;
using Blogoria.Models.Enums;

namespace Blogoria.DTOs.BlogDTOs
{
    public sealed class BlogFilterDto : BaseFilterDto
    {
        public int? BlogUserId { get; init; }
        public ReactionType? ReactionType { get; init; }
        public int? MinReactionsCount { get; init; }
        public int? MaxReactionsCount { get; init; }
        public int? MinCommentsCount { get; init; }
        public int? MaxCommentsCount { get; init; }
    }
}
