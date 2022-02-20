using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public CityRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }
        public List<City> FillCityDropDown(string postalCode)
        {
            //return _helperlandContext.Cities.Where(x => x.Zipcodes = postalCode).ToList();
            List<City> cities = (from City in _helperlandContext.Cities
                             join Zipcode in _helperlandContext.Zipcodes
                             on City.Id equals Zipcode.CityId
                             where Zipcode.ZipcodeValue == postalCode
                             select new City
                             {
                                 Id = City.Id,
                                 CityName = City.CityName

                             }).ToList();

            return cities;
        }
    }
}
