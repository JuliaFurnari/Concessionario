using Concessionario.Entities;
using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.ListRepository
{
    class BusListRepository : IBusDbManager
    {
        public static List<Bus> buses = new List<Bus>
        {
            new Bus("Iveco", "Euroclass", 10, null),
            new Bus("Renault", "Trafic", 8, null),
            new Bus("Fiat", "Talento", 12, null)
        };
        public void Delete(Bus bus)
        {
            buses.Remove(bus);
        }

        public List<Bus> Fetch()
        {
            return buses;
        }

        public Bus GetById(int? id)
        {
            return buses.Find(b => b.Id == id);
        }

        public void Insert(Bus bus)
        {
            buses.Add(bus);
        }

        public void Update(Bus bus)
        {
            Delete(GetById(bus.Id));
            Insert(bus);
        }
    }
}
