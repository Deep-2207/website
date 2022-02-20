using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    
    public class StateRepository : IStateRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public StateRepository(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
        }

        public State GetStateName(string cityName)
        {
            var objstate = (from city in _helperlandContext.Cities
                                  join state in _helperlandContext.States
                                  on city.StateId equals state.Id
                                  where city.CityName == cityName
                                  select new State
                                  {
                                      Id = state.Id,
                                      StateName = state.StateName

                                  }).FirstOrDefault();
            return objstate;
        }
    }
}
