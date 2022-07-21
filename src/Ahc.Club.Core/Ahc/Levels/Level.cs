using Ahc.Club.Ahc.Gifts;
using Ahc.Club.Shared;
using System.Collections.Generic;

namespace Ahc.Club.Ahc.Levels
{
    public class Level : AhcEntity
    {
        public Level()
        {
            Gifts = new List<Gift>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
        public string Color { get; set; }

        public virtual IList<Gift> Gifts { get; set; }
    }
}
