using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.Entities
{
    public class Motocycle: Vehicle
    {
        public int ProductionYear { get; set; }

        public Motocycle(string brand, string model, int year, int? id)
            : base(brand, model, id)
        {
            ProductionYear = year;
        }

        public Motocycle()
        {
        }

        public override string Print()
        {
            return $"{base.Print()}, {ProductionYear}";
        }
    }
}
