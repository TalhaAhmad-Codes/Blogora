namespace Blogoria.Contracts.UserComments
{
    // To add a user comment on a blog
    public sealed record CreateUserComment(
        int BlogId,
        string Comment
    );

    // To update a user comment on a blog
    public sealed record UpdateUserComment(
        int BlogId,
        string Comment
    );

    // Get comment on a blog
    public sealed record UserCommentReponse(
        int Id,
        int BlogId,
        string Comment,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
