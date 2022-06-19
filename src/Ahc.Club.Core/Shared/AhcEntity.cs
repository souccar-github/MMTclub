using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Ahc.Club.Shared
{
    public class AhcEntity : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
    }
}
