using Abp.Application.Services.Dto;
using Ahc.Club.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Ahc.Complaints.Dto
{
    public class ComplaintDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ComplaintDate { get; set; }
        public long? UserId { get; set; }
        //public virtual User User { get; set; }
    }
}
