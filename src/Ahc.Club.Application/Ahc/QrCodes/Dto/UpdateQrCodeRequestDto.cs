using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.QrCodes.Dto
{
   public class UpdateQrCodeRequestDto : EntityDto<int>
    {
        public DateTime? Date { get; set; }
        public int Count { get; set; }
        public int? ProductId { get; set; }
    }
}

