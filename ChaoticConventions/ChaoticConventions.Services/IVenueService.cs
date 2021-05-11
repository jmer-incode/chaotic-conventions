using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaoticConventions.Model;

namespace ChaoticConventions.Services
{
    public interface IVenueService
    {
        IEnumerable<Venue> GetVenues();
        void CreateVenue(Venue venue);
    }
}
