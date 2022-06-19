using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.QrCodes.Dto
{
   public class CreateQrCodeDto : EntityDto<int>
    {
        public bool IsTaken { get; set; }
        public string ImagePath { get; set; }
        public string Code { get; set; }
        public int? ProductSizeId { get; set; }
    }
}

