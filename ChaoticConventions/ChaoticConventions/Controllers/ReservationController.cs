using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ChaoticConventions.Model;
using ChaoticConventions.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChaoticConventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ISeatReservationService _seatReservationService;

        public ReservationController(ISeatReservationService seatReservationService)
        {
            _seatReservationService = seatReservationService;
        }
        // GET: api/<ReservationController>
        [HttpGet]
        public IEnumerable<SeatReservation> Get(string reservationNumber)
        {
            //_seatReservationService.GetSeat();
            throw new NotImplementedException();
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
