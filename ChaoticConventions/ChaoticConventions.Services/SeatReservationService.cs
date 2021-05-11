using System;
using ChaoticConventions.Model;
using ChaoticConventions.SQL;

namespace ChaoticConventions.Services
{
    public class SeatReservationService : ISeatReservationService
    {
        private readonly IRepository<SeatReservation> _seatReservationRepository;

        public SeatReservationService(IRepository<SeatReservation> seatReservationRepository)
        {
            _seatReservationRepository = seatReservationRepository;
        }
        
        public SeatReservation ReserveSeat()
        {
            throw new NotImplementedException();
        }

        public SeatReservation GetExistingSeatReservation(string reservationNumber)
        {
            throw new NotImplementedException();
        }
        
        public void CancelSeatReservation(string reservationNumber)
        {
            throw new NotImplementedException();
        }
    }
}
