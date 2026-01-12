namespace Blogoria.DTOs.UserCommentDTOs
{
    public sealed class AddUserCommentDto
    {
        public int UserId { get; init; }
        public int BlogId { get; init; }
        public string Comment { get; init; }
    }
}
