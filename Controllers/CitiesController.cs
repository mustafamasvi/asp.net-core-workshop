using System.Collections.Generic;
using System.Linq;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }
         
        [HttpGet()]
        public IActionResult GetCities()
        {
            var cityEntites = _cityInfoRepository.GetCities();

            var result = new List<CityWithoutPointsOfInterestDto>();

            foreach(var cityEntity in cityEntites)
            {
                result.Add(new CityWithoutPointsOfInterestDto {
                    Id = cityEntity.Id,
                    Name = cityEntity.Name,
                    Description = cityEntity.Description
                });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointOfInterest = false)
        {
            //var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            var city = _cityInfoRepository.GetCity(id,includePointOfInterest);
            if(city == null) {
                return NotFound();
            }

            if(includePointOfInterest){
                var cityResult = new CityDto() {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description
                };
                foreach (var poi in city.PointsOfInterest)
                {
                    cityResult.PointsOfInterest.Add(new PointOfInterestDto() {
                        Id = poi.Id,
                        Name = poi.Name,
                        Description = poi.Description
                    });
                }
                return Ok(cityResult);
            }
            else {
                var cityResult = new CityWithoutPointsOfInterestDto() {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description
                };
                return Ok(cityResult);
            }
        }
    } 
}