using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Luggage
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public float Weight { get; set; }

        public int? PassengerId { get; set; }
        public Passenger Passenger { get; set; }
    }
}
