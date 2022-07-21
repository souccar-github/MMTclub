using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Categories.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public string FirstImage { get; set; }
        public string SecondImage { get; set; }
        public string ThirdImage { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}

