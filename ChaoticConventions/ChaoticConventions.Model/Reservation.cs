using System;

namespace ChaoticConventions.Model
{
    public class SeatReservation
    {
        public SeatReservation(User user, Convention convention, UserConventionRole role)
        {
            User = user;
            Convention = convention;
            Role = role;
        }
        public User User { get; }
        public Convention Convention { get; }
        public UserConventionRole Role { get; }
        public 


    }
}
