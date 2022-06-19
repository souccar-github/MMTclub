using Abp.Application.Services.Dto;

namespace Ahc.Club.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

