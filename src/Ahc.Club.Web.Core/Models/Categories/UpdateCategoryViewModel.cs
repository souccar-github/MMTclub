using Microsoft.AspNetCore.Http;

namespace Ahc.Club.Models.Categories
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public int? ParentCategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
}
