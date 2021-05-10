using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaoticConventions.Model
{
    class Seat
    {
        public Guid Id { get; set; }
        public Room InRoom { get; set; }
    }
}
