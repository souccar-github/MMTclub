using Ahc.Club.Shared;

namespace Ahc.Club.Ahc.Categories
{
    public class CategoryNews : AhcEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        #region Category
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        #endregion
    }
}
