namespace Blogoria.Contracts.Blogs
{
    // To create a new blog
    public sealed record CreateBlogRequest(
        byte[]? FeaturedImage,
        string Title,
        string Description
    );

    // To update an existing blog
    public sealed record UpdateBlogRequest(
        byte[]? FeaturedImage,
        string Title,
        string Description
    );

    // To get blog
    public sealed record BlogResponse(
        int Id,
        byte[]? FeaturedImage,
        string Title,
        string Description,
        int AuthorId,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
