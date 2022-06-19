using Ahc.Club.Ahc.Categories;
using Ahc.Club.Shared;
using System.Collections.Generic;

namespace Ahc.Club.Ahc.Products
{
    public class Product : AhcEntity
    {
        public Product()
        {
            ProductSizes = new List<ProductSize>();
            ProductImages = new List<ProductImage>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }

        #region Category
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        #endregion

        public virtual IList<ProductSize> ProductSizes { get; set; }
        public virtual IList<ProductImage> ProductImages { get; set; }
    }
}
