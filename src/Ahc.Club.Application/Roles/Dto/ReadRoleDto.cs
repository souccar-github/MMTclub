using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Roles.Dto
{
    public class ReadRoleDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string normalizedName { get; set; }
        public string description { get; set; }
    }
}
