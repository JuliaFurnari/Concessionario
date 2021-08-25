using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.Entities
{
    class Bus: Vehicle
    {
        public int SeatsNumber { get; set; }

        public Bus(string brand, string model, int seats, int? id)
            :base(brand, model, id)
        {
            SeatsNumber = seats;
        }

        public Bus()
        {
        }

        public override string Print()
        {
            return $"{base.Print()}, {SeatsNumber}";
        }
    }
}
