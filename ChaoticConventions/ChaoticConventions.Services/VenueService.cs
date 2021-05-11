using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaoticConventions.Model;
using ChaoticConventions.SQL;

namespace ChaoticConventions.Services
{
    public class VenueService: IVenueService
    {
        private readonly IRepository<Venue> _venueRepository;

        public VenueService(IRepository<Venue> venueRepository)
        {
            _venueRepository = venueRepository;
        }
        public IEnumerable<Venue> GetVenues()
        {
            return _venueRepository.Get();
        }

        public void CreateVenue(Venue venue)
        {


            _venueRepository.Save(venue);
        }
    }
}
