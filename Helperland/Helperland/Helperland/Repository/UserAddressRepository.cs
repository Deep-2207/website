using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public UserAddressRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }


        public List<UserAddress> GetAllAddress(int userid)
        {
            List<UserAddress> addresses = _helperlandContext.UserAddresses.Where(x => x.UserId == userid).ToList();
            return addresses;
        }

        public UserAddress AddUserAddress(UserAddress userAddress)
        {
            _helperlandContext.UserAddresses.Add(userAddress);
            _helperlandContext.SaveChanges();
            return userAddress;
        }
        public UserAddress SelectAddressByID(int id)
        {
            return _helperlandContext.UserAddresses.Where(x => x.AddressId == id).FirstOrDefault();
        }
    }
}
