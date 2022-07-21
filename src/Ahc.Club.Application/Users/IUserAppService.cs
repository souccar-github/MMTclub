using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Ahc.Club.Roles.Dto;
using Ahc.Club.Shared.Dto;
using Ahc.Club.Users.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
        Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm);
        Task ChangeLanguage(ChangeUserLanguageDto input);
        Task<bool> ChangePassword(ChangePasswordDto input);
        Task<IList<UserForDropdownDto>> GetUsersForDropdown();
        Task<UserProfileDto> GetProfileAsync();
    }
}
