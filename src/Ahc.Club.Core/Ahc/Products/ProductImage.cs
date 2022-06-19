using Ahc.Club.Shared;

namespace Ahc.Club.Ahc.Products
{
    public class ProductImage : AhcEntity
    {
        public string Path { get; set; }
        public string Tag { get; set; }
        public bool IsPrimary { get; set; }

        #region Product
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}
