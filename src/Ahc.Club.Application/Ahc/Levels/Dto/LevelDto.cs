using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Gifts.Dto;

namespace Ahc.Club.Ahc.Levels.Dto
{
    public class LevelDto : EntityDto<int>
    {
        public LevelDto()
        {
            Gifts = new List<GiftDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FromPoint { get; set; }
        public int ToPoint { get; set; }
        public string Color { get; set; }
        public int Order { get; set; }
        public IList<GiftDto> Gifts { get; set; }
    }
}

