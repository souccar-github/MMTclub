using Abp.Authorization;
using Ahc.Club.Authorization.Roles;
using Ahc.Club.Authorization.Users;

namespace Ahc.Club.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
