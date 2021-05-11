using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ChaoticConventions.Model;
using ChaoticConventions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChaoticConventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;
        private readonly ILogger<VenueController> _logger;

        public VenueController(IVenueService venueService, ILogger<VenueController> logger)
        {
            _venueService = venueService;
            _logger = logger;
        }



        // GET: api/<VenueController>
        [HttpGet]
        [Authorize] // you can do role checks here
        public ActionResult<IEnumerable<Venue>> Get()
        {
            try
            {
                return Ok(_venueService.GetVenues());
            }
            catch (Exception ex) // potentially we could use exception filters here if we need to filter on something specific.
            {
                _logger.Log(LogLevel.Error, ex, "Something bad happened"); // I prefer to catch more specific exceptions if I can handle them correctly, but if something we didn't foresee happened we want to log it.
            }
            return NotFound();
        }

        // GET api/<VenueController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VenueController>
        [HttpPost]
        [Authorize]
        public void Post(Venue venue)
        {
            try
            {
                _venueService.CreateVenue(venue);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Something bad happened");
            }
            
        }

        // PUT api/<VenueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VenueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
