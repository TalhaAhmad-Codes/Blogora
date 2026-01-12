namespace Blogoria.DTOs.BlogDTOs
{
    public sealed class CreateBlogDto
    {
        public int AuthorId { get; init; }
        public byte[]? FeaturedImage { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
