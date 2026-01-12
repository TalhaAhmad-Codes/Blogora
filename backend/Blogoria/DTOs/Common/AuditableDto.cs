namespace Blogoria.DTOs.Common
{
    public abstract class AuditableDto : BaseDto
    {
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
