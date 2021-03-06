using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Settings.Dto
{
   public class ReadGeneralSettingDto : EntityDto<int>
    {
        public int initialPoint { get; set; }
        public int pointsFromFirstCheckQRCode { get; set; }
        public string facbook { get; set; }
        public string instagram { get; set; }
        public string youTube { get; set; }
        public string telegram { get; set; }
        public string twitter { get; set; }
    }
}

