using Helperland.Data;
using Helperland.Enums;
using Helperland.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public CustomerRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }

        public Rating AddRatings(Rating rating)
        {
            _helperlandContext.Ratings.Add(rating);
            _helperlandContext.SaveChanges();
            return rating;
        }

        public List<ServiceRequest> GetAllserviceBySPID(int? spid)
        {
            return _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == spid).ToList();
        }

        public List<ServiceRequest> GetAllServicebyUserid(int userid)
        {
            List<ServiceRequest> services = _helperlandContext.ServiceRequests.Where(x => x.UserId == userid).ToList();

            foreach (ServiceRequest s in services)
            {
                if (s.ServiceProviderId != null)
                {
                    s.Ratings = _helperlandContext.Ratings.Where(x => x.RatingTo == s.ServiceProviderId).ToList();
                    s.User = _helperlandContext.Users.Where(x => x.UserId == s.ServiceProviderId).FirstOrDefault();
                }
            }
            return services;
            //List<City> cities = (from user in _helperlandContext.Users
            //                     join servicerequest in _helperlandContext.ServiceRequests
            //                     on user.UserId equals servicerequest.UserId
            //                     join ratings in _helperlandContext.Ratings
            //                     on servicerequest.ServiceProviderId equals ratings.ServiceRequestId
            //                     where user.UserId == userid
            //                     select new User
            //                     {
            //                         UserId = user.UserId,
            //                         FirstName = user.FirstName,
            //                         LastName = user.LastName,
            //                         Email = user.Email,
            //                         Mobile = user.Mobile,
            //                         UserTypeId = user.UserTypeId,
            //                         WorksWithPets = user.WorksWithPets,
            //                         CreatedDate = user.CreatedDate,
            //                         ModifiedBy = user.ModifiedBy,
            //                         ModifiedDate = user.ModifiedDate,
            //                         IsApproved = user.IsApproved,
            //                      //  ServicerequestID = servicerequest.ServiceRequestId,

            //                     }).ToList();

            //return cities;
        }

        public List<ServiceRequestExtra> GetExtraservicesByServiceid(int srid)
        {
            return _helperlandContext.ServiceRequestExtras.Where(x => x.ServiceRequestId == srid).ToList();
        }

        public Rating GetRatingForServicerequest(int srid)
        {
            return _helperlandContext.Ratings.Where(x => x.ServiceRequestId == srid).FirstOrDefault();
        }

        public List<Rating> GetRatingsBySpid(int? spid, int? status)
        {
            List<Rating> ratings = _helperlandContext.Ratings.Where(x => x.RatingTo == spid && status != (int)ServiceStatusEnum.Cancel).ToList();
            return ratings;
        }

        public List<ServiceRequest> GetServiceHistoryBySpID(int spid)
        {
            List<ServiceRequest> servicehistory = _helperlandContext.ServiceRequests.Where(x => x.UserId == spid &&
                                                                                       (x.Status == (int)ServiceStatusEnum.completed ||
                                                                                       x.Status == (int)ServiceStatusEnum.Cancel)).ToList();
            return  servicehistory;
        }

        public User Getserviceprovider(int? spid)
        {
            return _helperlandContext.Users.Where(x => x.UserId == spid).Include(c => c.UserAddresses).FirstOrDefault();
        }

        public ServiceRequest GetserviceReqestDetials(int srid)
        {
            return _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == srid).FirstOrDefault();
        }

        public List<ServiceRequestAddress> GetServicerequestAddress(int srid)
        {
            return _helperlandContext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == srid).ToList();
        }

        public User GetUSerbyloginid(int userid)
        {
            return _helperlandContext.Users.Where(x => x.UserId == userid).Include(c => c.UserAddresses).FirstOrDefault();
            //ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceRequestId).Include(c => c.ServiceRequestExtras).FirstOrDefault();
            // return Json(new SingleEntity<ForgotViewModel> { Result = model, Status = "Error", ErrorMessage = "Please Enter the Registrated Email" });
        }

        public User UpdateUserDetils(User user)
        {
            _helperlandContext.Users.Update(user);
            _helperlandContext.SaveChanges();
            return user;
        }

        //useraddress

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

        public UserAddress UpdateAddress(UserAddress userAddress)
        {
            _helperlandContext.UserAddresses.Update(userAddress);
            _helperlandContext.SaveChanges();
            return (userAddress);
        }
        public UserAddress DeleteAddress(int addressid)
        {
            //_helperlandContext.UserAddresses.Remove(addressid);
            UserAddress selectedaddress = _helperlandContext.UserAddresses.Where(x => x.AddressId == addressid).FirstOrDefault();
            _helperlandContext.UserAddresses.Remove(selectedaddress);
            _helperlandContext.SaveChanges();

            return (selectedaddress);

        }

        public List<UserAddress> GetAllAddressbypostalcode(int userid, string postalcode)
        {
            List<UserAddress> addresses = _helperlandContext.UserAddresses.Where(x => x.UserId == userid && x.PostalCode == postalcode).ToList();
            return addresses;
        }
    }
}
