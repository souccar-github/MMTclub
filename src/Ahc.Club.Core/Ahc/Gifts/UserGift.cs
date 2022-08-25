using Ahc.Club.Authorization.Users;
using Ahc.Club.Shared;
using System;

namespace Ahc.Club.Ahc.Gifts
{
    public class UserGift : AhcEntity
    {
        #region Gift
        public int? GiftId { get; set; }
        public virtual Gift Gift { get; set; }
        #endregion

        #region User
        public long? UserId { get; set; }
        public virtual User User { get; set; }
        #endregion

        public DateTime? Date { get; set; }
        public UserGiftStatus Status { get; set; }
        public string Description { get; set; }
    }
}
