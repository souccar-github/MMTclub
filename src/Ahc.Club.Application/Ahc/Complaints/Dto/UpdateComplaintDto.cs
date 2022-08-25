using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Complaints.Dto
{
   public class UpdateComplaintDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ComplaintDate { get; set; }
    }
}

