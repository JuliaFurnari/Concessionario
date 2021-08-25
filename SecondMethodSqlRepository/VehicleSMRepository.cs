using Concessionario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.SecondMethodSqlRepository
{
    class VehicleSMRepository
    {
        public static MotocycleSMRepository motocycleRepository = new MotocycleSMRepository();
        public static CarSMRepository carRepository = new CarSMRepository();
        public static BusSMRepository busRepository = new BusSMRepository();
        public List<Vehicle> Fetch()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.AddRange(motocycleRepository.Fetch());
            vehicles.AddRange(carRepository.Fetch());
            vehicles.AddRange(busRepository.Fetch());

            return vehicles;
        }
    }
}
