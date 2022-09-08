using Ahc.Club.Shared;

namespace Ahc.Club.Ahc.Settings
{
    public class GeneralSetting : AhcEntity
    {
        public int InitialPoint { get; set; }
        public int PointsFromFirstCheckQRCode { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string YouTube { get; set; }
        public string Telegram { get; set; }
        public string MobilePhone { get; set; }
    }
}
