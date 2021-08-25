using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.Entities
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Id { get; set; }


        public Vehicle()
        {

        }
        public Vehicle(string brand, string model, int? id)
        {
            Brand = brand;
            Model = model;
            Id = id;
        }

        public virtual string Print()
        {
            return $"{Brand}, {Model}";
        }
    }
}
