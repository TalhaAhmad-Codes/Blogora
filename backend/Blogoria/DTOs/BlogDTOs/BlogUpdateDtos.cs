using Blogoria.DTOs.Common;

namespace Blogoria.DTOs.BlogDTOs.BlogUpdateDtos
{
    public sealed class BlogUpdateFeaturedImageDto : BaseDto
    {
        public byte[]? FeaturedImage { get; init; }
    }

    public sealed class BlogUpdateTitleDto : BaseDto
    {
        public string Title { get; init; }
    }

    public sealed class BlogUpdateDescriptionDto : BaseDto
    {
        public string Description { get; init; }
    }
}
