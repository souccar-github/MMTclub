using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Authorization.Accounts.Dto;

namespace Ahc.Club.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
