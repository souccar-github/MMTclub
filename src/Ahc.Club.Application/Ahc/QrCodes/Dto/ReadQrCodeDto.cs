using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.QrCodes.Dto
{
   public class ReadQrCodeDto : EntityDto<int>
    {
        public bool isTaken { get; set; }
        public string imagePath { get; set; }
        public string code { get; set; }
        public int? productSizeId { get; set; }
    }
}

