using Ahc.Club.Ahc.Categories.Dto;
using Ahc.Club.Ahc.Levels.Dto;
using Ahc.Club.Users.Dto;
using System.Collections.Generic;

namespace Ahc.Club.Ahc.Home.Dto
{
    public class HomeDto
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public double UserPoints { get; set; }
        public UserProfileLevelDto Level { get; set; }
        public IList<ParentCategoryDto> Categories { get; set; }

    }
}
