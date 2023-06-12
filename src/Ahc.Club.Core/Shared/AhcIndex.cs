using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Shared
{
    public class AhcIndex: AhcAggregateRoot
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
