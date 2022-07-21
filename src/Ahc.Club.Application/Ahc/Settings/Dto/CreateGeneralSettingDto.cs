using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Settings.Dto
{
   public class CreateGeneralSettingDto : EntityDto<int>
    {
        public int InitialPoint { get; set; }
        public int PointsFromFirstCheckQRCode { get; set; }
        public string Facbook { get; set; }
        public string Instagram { get; set; }
        public string YouTube { get; set; }
        public string Telegram { get; set; }
        public string Twitter { get; set; }
    }
}

