using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface IUserAddressRepository
    {
        List<UserAddress> GetAllAddress(int userid);

        public UserAddress AddUserAddress(UserAddress userAddress);
        public UserAddress SelectAddressByID(int id);
    }
}
