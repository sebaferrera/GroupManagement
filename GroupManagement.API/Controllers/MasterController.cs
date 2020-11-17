using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupManagement.Contracts;
using GroupManagement.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupManagement.API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the Master tables in the database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class MasterController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IActionResultService _actionResultService;
        public MasterController(
            ICityService cityService,
            ICountryService countryService,
            IActionResultService actionResultService)
        {
            _cityService = cityService;
            _countryService = countryService;
            _actionResultService = actionResultService;
        }

        /// <summary>
        /// Get All Cities
        /// </summary>
        /// <returns>List of Cities</returns>
        [HttpGet]
        [Route("cities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var cities = await _cityService.GetAll();
                if (cities == null || cities.Count == 0)
                {
                    return NotFound();
                }
                return Ok(cities);
            }
            catch (Exception e) 
            {
                return _actionResultService.InternalError(e);
            }
        }

        /// <summary>
        /// Get a city
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single city</returns>
        [HttpGet]
        [Route("cities/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCity(int id)
        {
            try
            {
                var city = await _cityService.GetById(id);
                if (city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception e)
            {
                return _actionResultService.InternalError(e);
            }
        }

        [HttpPost]
        [Route("city")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCity([FromBody] CityCreateDTO city)
        {
            var location = GetControllerActionNames();
            try
            {
                if (city == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var created = await _cityService.Create(city);
                if (created == null)
                {
                    return _actionResultService.InternalError($"{location}: Creation failed");
                }
                
                return Created("Create", new { created });
            }
            catch (Exception e)
            {
                return _actionResultService.InternalError(e);
            }
        }

        /// <summary>
        /// Get All Countries
        /// </summary>
        /// <returns>List of Countries</returns>
        [HttpGet]
        [Route("countries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _countryService.GetAll();
                if (countries == null || countries.Count == 0)
                {
                    return NotFound();
                }
                return Ok(countries);
            }
            catch (Exception e)
            {
                return _actionResultService.InternalError(e);
            }
        }

        /// <summary>
        /// Get a country
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single country</returns>
        [HttpGet]
        [Route("countries/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _countryService.GetById(id);
                if (country == null)
                {
                    return NotFound();
                }
                return Ok(country);
            }
            catch (Exception e)
            {
                return _actionResultService.InternalError(e);
            }
        }

        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

    }
}