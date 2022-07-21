using Ahc.Club.Ahc.Products;
using Ahc.Club.Shared;
using System;

namespace Ahc.Club.Ahc.QrCodes
{
    public class QrCodeRequest : AhcEntity
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }

        #region Product
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}
