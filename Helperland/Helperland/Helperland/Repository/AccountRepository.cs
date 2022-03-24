using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public AccountRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }

        public User GetLoginuser(string Email, string Password)
        {
            return _helperlandContext.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
        }

        public User GetUserByEmail(string Email)
        {
            return _helperlandContext.Users.Where(x => x.Email == Email).FirstOrDefault();
        }

        public User UpdateUser(User user)
        {
            _helperlandContext.Add(user);
            _helperlandContext.SaveChanges();
            return user;
        }
    }
}
