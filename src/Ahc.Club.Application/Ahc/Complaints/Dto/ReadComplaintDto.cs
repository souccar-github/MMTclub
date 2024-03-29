using System;
using Abp.Application.Services.Dto;
using Ahc.Club.Users.Dto;

namespace Ahc.Club.Ahc.Complaints.Dto
{
   public class ReadComplaintDto : EntityDto<int>
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime? complaintDate { get; set; }
        public ReadUserDto User { get; set; }
    }
}

