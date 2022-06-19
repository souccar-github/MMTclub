using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Sessions.Dto;

namespace Ahc.Club.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
