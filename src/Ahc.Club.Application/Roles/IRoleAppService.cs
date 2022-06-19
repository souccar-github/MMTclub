using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Ahc.Club.Roles.Dto;
using Ahc.Club.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm);
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
        IList<FlatPermissionDto> GetPermissions();
        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);
        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
    }
}
