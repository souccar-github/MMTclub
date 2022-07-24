
using Ahc.Club.Ahc.Categories.Services;
using Ahc.Club.Ahc.Home.Dto;
using Ahc.Club.Users;
using System.Threading.Tasks;

namespace Ahc.Club.Ahc.Home
{
    public class HomeAppService : ExchangeAppServiceBase, IHomeAppService
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IUserAppService _userAppService;

        public HomeAppService(ICategoryAppService categoryAppService, IUserAppService userAppService)
        {
            _categoryAppService = categoryAppService;
            _userAppService = userAppService;
        }

        public async Task<HomeDto> GetAsync()
        {
            var profile = await _userAppService.GetProfileAsync();
            var parentCategories = _categoryAppService.GetParent();

            return new HomeDto()
            {
                Categories = parentCategories,
                FullName = profile.FullName,
                Level = profile.Level,
                Points = profile.Points,
                Username = profile.Username
            };
        }
    }
}
