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
        List<UserAddress> GetAllAddressbypostalcode(int userid,string postalcode);
        public UserAddress AddUserAddress(UserAddress userAddress);
        public UserAddress SelectAddressByID(int id);
        public UserAddress UpdateAddress(UserAddress userAddress);
        public UserAddress DeleteAddress(int id);
      //  public UserAddress GetAddressDetialsbyUserid(int userid);
    }
}
