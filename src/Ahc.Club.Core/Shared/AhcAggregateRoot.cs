using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Shared
{
    public class AhcAggregateRoot: FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }
    }
}
