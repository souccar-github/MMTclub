using Ahc.Club.Authorization.Users;
using Ahc.Club.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Ahc.Complaints
{
    public class Complaint : AhcEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ComplaintDate { get; set; }
        #region User
        public long? UserId { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}