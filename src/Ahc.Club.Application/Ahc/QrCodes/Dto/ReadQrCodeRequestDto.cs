using System;
using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Products.Dto;

namespace Ahc.Club.Ahc.QrCodes.Dto
{
   public class ReadQrCodeRequestDto : EntityDto<int>
    {
        public DateTime? date { get; set; }
        public int count { get; set; }
        public int? productId { get; set; }
        public ReadProductDto product { get; set; }
    }
}

