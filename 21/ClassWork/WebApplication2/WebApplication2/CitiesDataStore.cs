using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Controllers.Models;

namespace WebApplication2
{
    public class CitiesDataStore
    {
        private static CitiesDataStore _store;
        public List<City> Cities { get; }


        private CitiesDataStore()
        {
            Cities = new List<City>
            {
                new City (1,"Moscow"),
                new City (2, "Saint Petersburg"),
                new City (3, "London")
            };
        }
        public static CitiesDataStore GetInstance()
        {
            if(_store == null)
            {
                _store = new CitiesDataStore();
            }
            return _store;
        }
    }
}
