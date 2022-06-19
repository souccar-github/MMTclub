using Ahc.Club.Ahc.Indexes;
using Ahc.Club.Shared;

namespace Ahc.Club.Ahc.Products
{
    public class ProductSize:AhcEntity
    {
        public double Point { get; set; }

        #region Product
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion

        #region Size
        public int? SizeId { get; set; }
        public virtual Size Size { get; set; }
        #endregion
    }
}
