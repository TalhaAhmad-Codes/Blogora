namespace Blogoria.DTOs.Common
{
    public class AuditableDto : BaseDto
    {
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
