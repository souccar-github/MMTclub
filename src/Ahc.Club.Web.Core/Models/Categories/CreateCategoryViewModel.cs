using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Models.Categories
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public int? ParentCategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
}
