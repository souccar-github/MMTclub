using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Ahc.Categories.Dto
{
    public class CategoryNewsPagedResult
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Keyword { get; set; }

    }
}
