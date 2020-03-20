using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Controllers.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CitiesController : Controller
    {
        private CitiesDataStore _store;
        public CitiesController()
        {
            _store = CitiesDataStore.GetInstance();
        }
        [HttpGet]
        public IActionResult GetCities()
        {
            return new JsonResult(_store.Cities);
        }
        [HttpGet("{id}", Name = "GetCityById")]
        public IActionResult GetCity(int id)
        {
            var city = _store.Cities.FirstOrDefault(x => x.Id == id);
            if (city != null)
            {
                //200 OK
                return Ok(new JsonResult(city));
            }
            else
            {
                return NotFound("Not Found");
            }
        }
        [HttpPost]
        public IActionResult AddCity([FromBody] string text)
        {
            var city = new City(_store.Cities.Count() + 1, text);
            if (_store.Cities.FirstOrDefault(x => (x.Name == text)) != null)
                return Conflict();
            _store.Cities.Add(city);
            return CreatedAtRoute("GetCityById", new { id = city.Id }, city);
        }
        [HttpPut]
        public IActionResult EditCity([FromBody] City cityEdited)
        {
            var city = _store.Cities.FirstOrDefault(x => x.Id == cityEdited.Id);
            if (city != null)
            {
                var cityId = _store.Cities.IndexOf(city);
                _store.Cities[cityId] = cityEdited;
                return Ok(new JsonResult(cityEdited));
            }
            else
            {
                return NotFound("Not Found");
            }
        }
        [HttpDelete]
        public IActionResult DeleteCity ([FromBody] int id)
        {
            var city = _store.Cities.FirstOrDefault(x => x.Id == id);
            if (city != null)
            {
                _store.Cities.Remove(city);
                return Ok($"Removed id{id}");
            }
            else
            {
                return NotFound("Not Found");
            }
        }
    }
}
