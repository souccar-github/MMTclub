using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Ahc.Categories.Dto
{
    public class ParentCategoryDto : CategoryDto
    {
        public ParentCategoryDto()
        {
            News = new List<CategoryNewsDto>();
        }
        public IList<CategoryNewsDto> News { get; set; }
    }
}
