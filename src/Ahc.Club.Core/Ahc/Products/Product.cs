using Ahc.Club.Ahc.Categories;
using Ahc.Club.Ahc.QrCodes;
using Ahc.Club.Shared;
using System.Collections.Generic;

namespace Ahc.Club.Ahc.Products
{
    public class Product : AhcEntity
    {
        public Product()
        {
            QrCodes = new List<QrCode>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public string FirstImage { get; set; }
        public string SecondImage { get; set; }
        public string ThirdImage { get; set; }


        #region Category
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        #endregion

        public virtual IList<QrCode> QrCodes { get; set; }
    }
}
