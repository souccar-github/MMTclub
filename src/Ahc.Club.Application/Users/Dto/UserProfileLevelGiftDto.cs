using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Gifts.Dto;

namespace Ahc.Club.Users.Dto
{
    public class UserProfileLevelGiftDto : EntityDto
    {
        public UserProfileLevelGiftDto(GiftDto gift, bool isActive)
        {
            Name = gift.Name;
            Description = gift.Description;
            Image = gift.Image;
            IsActive = isActive;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}
