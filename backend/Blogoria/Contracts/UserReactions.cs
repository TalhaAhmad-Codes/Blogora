using Blogoria.Models.Enums;

namespace Blogoria.Contracts.UserReactions
{
    // To react on a blog
    public sealed record CreateUserReactionRequest(
        int BlogId,
        ReactionType ReactionType
    );

    // To Update a reaction on a blog
    public sealed record UpdateUserReactionRequest(
        int BlogId,
        ReactionType ReactionType
    );

    // To get reaction on a blog
    public sealed record UserReactionResponse(
        int Id,
        int BlogId,
        ReactionType ReactionType,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
