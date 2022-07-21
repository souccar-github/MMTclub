using Ahc.Club.Ahc.Levels;
using Ahc.Club.Ahc.Products;
using Ahc.Club.Shared;

namespace Ahc.Club.Ahc.Gifts
{
    public class Gift : AhcEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        //public bool IsProduct { get; set; }

        //#region Product
        //public int? ProductId { get; set; }
        //public virtual Product Product { get; set; }
        //#endregion

        #region Level
        public int? LevelId { get; set; }
        public virtual Level Level { get; set; }
        #endregion
    }
}
