using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Shukratar.Domain.Account;

namespace Shukratar.Shared.Security
{
    public class ApplicationUser : IUser<int>
    {
        private readonly User _user;

        public ApplicationUser(User user)
        {
            _user = user;
        }

        public int Id => _user.Id;

        public string UserName
        {
            get { return _user.Username; }
            set { _user.Username = value; }
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            throw new System.NotImplementedException();
        }
    }
}