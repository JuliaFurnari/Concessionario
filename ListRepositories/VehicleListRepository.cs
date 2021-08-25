using Concessionario.Entities;
using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.ListRepository
{
    class VehicleListRepository : IVehicleDbManager
    {
        static List<Vehicle> vehicles = new List<Vehicle>();

        public static MotocycleListRepository motocycleRepository = new MotocycleListRepository();
        public static CarListRepository carRepository = new CarListRepository();
        public static BusListRepository busRepository = new BusListRepository();

        public void Delete(Vehicle vechile)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> Fetch()
        {
            if(vehicles.Count() > 0)
            {
                vehicles.Clear();
            }

            vehicles.AddRange(motocycleRepository.Fetch());
            vehicles.AddRange(carRepository.Fetch());
            vehicles.AddRange(busRepository.Fetch());

            return vehicles;
        }

        public Vehicle GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle vechile)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vechile)
        {
            throw new NotImplementedException();
        }
    }
}
