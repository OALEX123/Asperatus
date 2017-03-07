using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Shukratar.Domain.Account;
using Shukratar.Domain.Common;

namespace Shukratar.Shared.Security
{
    public class UserStore : IUserStore<ApplicationUser, int>
    {
        private readonly IRepository<User> _users;

        public UserStore(IRepository<User> users)
        {
            _users = users;
        }

        public void Dispose()
        {
        }

        public Task CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> FindByIdAsync(int userId)
        {
            var user = await _users.FirstOrDefaultAsync(x => x.Id == userId);

            return user == null ? null : new ApplicationUser(user);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var user = await _users.FirstOrDefaultAsync(x => x.Username == userName);

            return user == null ? null : new ApplicationUser(user);
        }
    }
}