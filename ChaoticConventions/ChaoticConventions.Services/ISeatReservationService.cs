using ChaoticConventions.Model;

namespace ChaoticConventions.Services
{
    public interface ISeatReservationService
    {
        SeatReservation ReserveSeat();
        SeatReservation GetExistingSeatReservation(string reservationNumber);
        void CancelSeatReservation(string reservationNumber);
    }
}