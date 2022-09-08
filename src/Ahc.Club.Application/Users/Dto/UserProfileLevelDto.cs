using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Levels.Dto;
using System.Collections.Generic;

namespace Ahc.Club.Users.Dto
{
    public class UserProfileLevelDto : EntityDto
    {
        public UserProfileLevelDto()
        {

        }

        public UserProfileLevelDto(LevelDto level)
        {
            if(level != null)
            {
                Gifts = new List<UserProfileLevelGiftDto>();
                Name = level.Name;
                Description = level.Description;
                FromPoint = level.FromPoint;
                ToPoint = level.ToPoint;
                Color = level.Color;
                Order = level.Order;
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FromPoint { get; set; }
        public int ToPoint { get; set; }
        public string Color { get; set; }
        public int Order { get; set; }
        public IList<UserProfileLevelGiftDto> Gifts { get; set; }
    }
}
