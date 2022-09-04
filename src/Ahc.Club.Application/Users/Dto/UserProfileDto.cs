using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Levels.Dto;

namespace Ahc.Club.Users.Dto
{
    public class UserProfileDto : EntityDto<long>
    {
        public UserProfileDto(string fullName, string username, double points, UserProfileLevelDto level)
        {
            FullName = fullName;
            Username = username;
            UserPoints = points;
            Level = level;
        }

        public string FullName { get; set; }
        public string Username { get; set; }
        public double UserPoints { get; set; }
        public UserProfileLevelDto Level { get; set; }
        public bool IsActive { get; set; }


    }
}
