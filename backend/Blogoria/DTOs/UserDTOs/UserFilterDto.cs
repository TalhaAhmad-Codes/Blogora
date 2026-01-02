using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.UserDTOs
{
    public sealed class UserFilterDto : BaseFilterDto
    {
        public string? Username { get; init; }
        public string? Email { get; init; }
    }
}
