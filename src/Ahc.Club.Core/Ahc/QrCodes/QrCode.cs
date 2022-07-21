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

        #region Product
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion

        #region QrCode Request
        public int? QrCodeRequestId { get; set; }
        public virtual QrCodeRequest QrCodeRequest { get; set; }
        #endregion

        #region User
        public long? UserId { get; set; }
        public virtual User User { get; set; }
        #endregion

    }
}
