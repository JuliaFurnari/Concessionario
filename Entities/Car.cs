using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.Entities
{
    class Car: Vehicle
    {
        public PowerSupply Supply { get; set; }
        public int DoorsNumber { get; set; }

        public Car(string brand, string model, PowerSupply supply, int doors, int? id)
            : base(brand, model, id)
        {
            Supply = supply;
            DoorsNumber = doors;
        }

        public Car()
        {
        }

        public override string Print()
        {
            return $"{base.Print()}, {Supply}, {DoorsNumber}";
        }

    }

    enum PowerSupply
    {
        Diesel,
        Gas,
        Eletric
    }
}
