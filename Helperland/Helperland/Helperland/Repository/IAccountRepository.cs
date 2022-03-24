using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface IAccountRepository
    {
        User UpdateUser(User user);
        User GetLoginuser(string Email, string Password);
        User GetUserByEmail(string Email);
    }
}
