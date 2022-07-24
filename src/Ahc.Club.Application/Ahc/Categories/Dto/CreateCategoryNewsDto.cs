using Abp.Application.Services.Dto;
using Ahc.Club.Shared.Dto;

namespace Ahc.Club.Ahc.Categories.Dto
{
    public class CreateCategoryNewsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public FileUploadDto Image { get; set; }
    }
}

