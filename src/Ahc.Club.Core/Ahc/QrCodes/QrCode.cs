using Ahc.Club.Ahc.Products;
using Ahc.Club.Authorization.Users;
using Ahc.Club.Shared;

namespace Ahc.Club.Ahc.QrCodes
{
    public class QrCode : AhcEntity
    {
        public bool IsTaken { get; set; }
        public string ImagePath { get; set; }
        public string Code { get; set; }

        #region ProductSize
        public int? ProductSizeId { get; set; }
        public virtual ProductSize ProductSize { get; set; }
        #endregion

        #region User
        public long? UserId { get; set; }
        public virtual User User { get; set; }
        #endregion

    }
}
