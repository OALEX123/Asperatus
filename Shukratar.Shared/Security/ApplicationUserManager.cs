using Microsoft.AspNet.Identity;

namespace Shukratar.Shared.Security
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store) : base(store)
        {
        }
    }
}