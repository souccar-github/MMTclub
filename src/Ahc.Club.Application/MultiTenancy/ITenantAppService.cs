using Abp.Application.Services;
using Ahc.Club.MultiTenancy.Dto;

namespace Ahc.Club.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

