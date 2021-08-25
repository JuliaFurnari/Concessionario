using Concessionario.Entities;
using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.ListRepository
{
    class CarListRepository : ICarDbManager
    {
        public static List<Car> cars = new List<Car>
        {
            new Car("Fiat", "500", PowerSupply.Diesel, 3, null),
            new Car("Tesla", "Model X", PowerSupply.Eletric, 5, null),
            new Car("Lancia", "Y", PowerSupply.Gas, 5, null)
        };
        public void Delete(Car car)
        {
            cars.Remove(car);
        }

        public List<Car> Fetch()
        {
            return cars;
        }

        public Car GetById(int? id)
        {
            return cars.Find(c => c.Id == id);
        }

        public void Insert(Car car)
        {
            cars.Add(car);
        }

        public void Update(Car car)
        {
            Delete(GetById(car.Id));
            Insert(car);
        }
    }
}
