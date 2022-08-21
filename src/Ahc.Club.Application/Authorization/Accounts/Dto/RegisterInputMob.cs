using Abp.Auditing;
using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ahc.Club.Authorization.Accounts.Dto
{
    public class RegisterInputMob
    {
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }


        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        
    }
}
