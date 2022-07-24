using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Levels.Dto;

namespace Ahc.Club.Users.Dto
{
    public class UserProfileDto : EntityDto<long>
    {
        public UserProfileDto(string fullName, string username, double points, LevelDto level)
        {
            FullName = fullName;
            Username = username;
            Points = points;
            Level = level;
        }

        public string FullName { get; set; }
        public string Username { get; set; }
        public double Points { get; set; }
        public LevelDto Level { get; set; }
        

    }
}
