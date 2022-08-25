using Ahc.Club.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Ahc.Notifications
{
    public class FcmNotification:AhcEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public long UserId { get; set; }
        public DistType DistType { get; set; }
        public int? DistId { get; set; }
        public bool IsRead { get; set; }
    }
}
