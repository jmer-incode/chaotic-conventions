using System;

namespace ChaoticConventions.Model
{
    public class SeatReservation
    {
        public SeatReservation(User user, Convention convention, UserConventionRole role, Seat seat)
        {
            User = user;
            Convention = convention;
            Role = role;
            Seat = seat;
        }
        public User User { get; }
        public Convention Convention { get; }
        public UserConventionRole Role { get; }
        public Seat Seat { get; }

        public TalkSchedule TalkSchedule { get; set; }
        //public 


    }
}
