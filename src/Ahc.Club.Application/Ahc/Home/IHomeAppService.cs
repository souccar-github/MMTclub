using Abp.Application.Services;
using Ahc.Club.Ahc.Home.Dto;
using System.Threading.Tasks;

namespace Ahc.Club.Ahc.Home
{
    public interface IHomeAppService : IApplicationService
    {
        Task<HomeDto> GetAsync();
        
    }
}
