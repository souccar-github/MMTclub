﻿using Ahc.Club.Shared;
using System.Collections.Generic;

namespace Ahc.Club.Ahc.Categories
{
    public class Category : AhcEntity
    {
        public Category()
        {
            ChildCategories = new List<Category>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public string Image { get; set; }


        #region Parent Category
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        #endregion

        public virtual IList<Category> ChildCategories { get; set; }
        public virtual IList<CategoryNews> News { get; set; }

    }
}
