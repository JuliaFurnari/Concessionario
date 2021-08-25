using Concessionario.Entities;
using Concessionario.FirstMethodSqlRepository;
using Concessionario.ListRepository;
using Concessionario.SecondMethodSqlRepository;
using Concessionario.ThirdMethodRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class DealerManager
    {
        // i repository che chiamano le classi con le liste statiche
        //public static VehicleListRepository vehicleRepository = new VehicleListRepository();
        //public static MotocycleListRepository motocycleRepository = new MotocycleListRepository();
        //public static CarListRepository carRepository = new CarListRepository();
       //public static BusListRepository busRepository = new BusListRepository();

        // i repository che chiamano le classi con ado e il first method(4 tabelle compresa la tabella padre
        //public static MotocycleFMRepository motocycleRepository = new MotocycleFMRepository();
       // public static BusFMRepository busRepository = new BusFMRepository();
        //public static CarFMRepository carRepository = new CarFMRepository();
        //public static VehicleFMRepository vehicleRepository = new VehicleFMRepository();

        // i repository che chiamano le classi con ado e il second method(3 tabelle -> escludo la tabella padre
       // public static MotocycleSMRepository motocycleRepository = new MotocycleSMRepository();
      //  public static CarSMRepository carRepository = new CarSMRepository();
       // public static BusSMRepository busRepository = new BusSMRepository();
        public static VehicleSMRepository vehicleRepository = new VehicleSMRepository();

        //i repository che chiamano le classi con ado e il third method con un'unica tabella con il discriminator
        public static MotocycleTMRepository motocycleRepository = new MotocycleTMRepository();
        public static CarTMRepository carRepository = new CarTMRepository();
        public static BusTMRepository busRepository = new BusTMRepository();
        internal static void ShowVehicles()
        {
            List<Vehicle> vehicles = vehicleRepository.Fetch();
            foreach(var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Print());
            }
        }

        internal static void ShowMotocycles()
        {
            List<Motocycle> motocycles = motocycleRepository.Fetch();
            foreach(var motocycle in motocycles)
            {
                Console.WriteLine(motocycle.Print());
            }
        }

        internal static void ShowCars()
        {
            List<Car> cars = carRepository.Fetch();
            foreach(var car in cars)
            {
                Console.WriteLine(car.Print());
            }
        }

        internal static void ShowBuses()
        {
            List<Bus> buses = busRepository.Fetch();
            foreach (var bus in buses)
            {
                Console.WriteLine(bus.Print());
            }

        }

        internal static void SellVehicle()
        {
            int tipoVeicolo;
            bool isInt;

            do
            {
                Console.WriteLine("Che veicolo vuoi acquistare?");
                Console.WriteLine("Premi 1 per acquistare una moto");
                Console.WriteLine("Premi 2 per acquistare un'auto");
                Console.WriteLine("Premi 3 per acquistare un pulmino");

                isInt = int.TryParse(Console.ReadLine(), out tipoVeicolo);

            } while (!isInt || tipoVeicolo <= 0 || tipoVeicolo >= 4);

            switch (tipoVeicolo)
            {
                case 1:
                    Motocycle motocycle = ScegliMoto();
                    motocycleRepository.Delete(motocycle);
                    break;
                case 2:
                    Car car = ScegliAuto();
                    carRepository.Delete(car);
                    break;
                case 3:
                    Bus bus = ScegliBus();
                    busRepository.Delete(bus);
                    break;
            }
        }

        private static Bus ScegliBus()
        {
            List<Bus> buses = busRepository.Fetch();

            int i = 1;
            foreach (var bus in buses)
            {
                Console.WriteLine($"Premi {i} per acquistare {bus.Print()}");
                i++;
            }

            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > buses.Count);

            return buses.ElementAt(veicoloScelto - 1);
        }

        private static Car ScegliAuto()
        {
            List<Car> cars = carRepository.Fetch();

            int i = 1;
            foreach (var car in cars)
            {
                Console.WriteLine($"Premi {i} per acquistare {car.Print()}");
                i++;
            }

            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > cars.Count);

            return cars.ElementAt(veicoloScelto - 1);
        }

        private static Motocycle ScegliMoto()
        {
            List<Motocycle> motocycles = motocycleRepository.Fetch();

            int i = 1;
            foreach(var motocycle in motocycles)
            {
                Console.WriteLine($"Premi {i} per acquistare {motocycle.Print()}");
                i++;
            }

            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > motocycles.Count);

            return motocycles.ElementAt(veicoloScelto - 1);
        }

        internal static void InsertVehicles()
        {
            int veicoloScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Che veicolo vuoi inserire?");
                Console.WriteLine("Premi 1 per inserire una nuova moto");
                Console.WriteLine("Premi 2 per inserire una nuova auto");
                Console.WriteLine("Premi 3 per inserire un nuovo pulmino");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto >= 4);

            switch(veicoloScelto)
            {
                case 1:
                    Motocycle motocycle = ChiediDatiMoto();
                    motocycleRepository.Insert(motocycle);
                    break;
                case 2:
                    Car car = ChiediDatiAuto();
                    carRepository.Insert(car);
                    break;
                case 3:
                    Bus bus = ChiediDatiBus();
                    busRepository.Insert(bus);
                    break;
            }

        }
        private static Bus ChiediDatiBus()
        {
            Vehicle vehicle = ChiediDatiVeicolo();
            Bus bus = new Bus();
            bus.Brand = vehicle.Brand;
            bus.Model = vehicle.Model;

            int numeroPosti;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci il numero di posti");
                isInt = int.TryParse(Console.ReadLine(), out numeroPosti);
            } while (!isInt);
            bus.SeatsNumber = numeroPosti;

            return bus;
        }
        private static Car ChiediDatiAuto()
        {
            Vehicle vehicle = ChiediDatiVeicolo();
            Car car = new Car();
            car.Model = vehicle.Model;
            car.Brand = vehicle.Brand;

            int alimentazione;
            bool isInt;
            do
            {
                Console.WriteLine("Scegli un genere");
                foreach (var genere in Enum.GetValues(typeof(PowerSupply)))
                {
                    Console.WriteLine($"Premi {(int)genere + 1} per {(PowerSupply)genere}");
                }
                isInt = int.TryParse(Console.ReadLine(), out alimentazione);

            } while (!isInt || alimentazione <= 0 || alimentazione >= 4);

            car.Supply = (PowerSupply)(alimentazione - 1);

            int numeroPorte;
            do
            {
                Console.WriteLine("Inserisci il numero di porte");
                isInt = int.TryParse(Console.ReadLine(), out numeroPorte);
            } while (!isInt);

            car.DoorsNumber = numeroPorte;

            return car;
        }

        private static Motocycle ChiediDatiMoto()
        {
            Vehicle vehicle = ChiediDatiVeicolo();

            Motocycle motocycle = new Motocycle();
            motocycle.Brand = vehicle.Brand;
            motocycle.Model = vehicle.Model;

            bool isInt;
            int annoProduzione;
            do
            {
                Console.WriteLine("Inserisci l'anno di produzione");

                isInt = int.TryParse(Console.ReadLine(), out annoProduzione);

            } while (!isInt);

            motocycle.ProductionYear = annoProduzione;

            return motocycle;
        }

        private static Vehicle ChiediDatiVeicolo()
        {
            Vehicle vehicle = new Vehicle();

            Console.WriteLine("Inserisci la marca");
            vehicle.Brand = Console.ReadLine();

            Console.WriteLine("Inserisci il modello");
            vehicle.Model = Console.ReadLine();

            return vehicle;
        }
    }
}
