using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupManagement.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupManagement.API.Controllers
{
    /// <summary>
    /// This is the Home Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILoggerService _logger;
        public HomeController(ILoggerService logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get a List of values
        /// </summary>
        /// <returns></returns>
        // GET: api/Home
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Accessed Get a list of values");
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Gets a single value 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            _logger.LogInfo("Accessed Get a single value");
            return "value";
        }

        // POST: api/Home
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
