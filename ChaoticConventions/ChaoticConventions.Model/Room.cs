using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaoticConventions.Model
{
    class Room
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Venue Venue { get; set; }

    }
}
