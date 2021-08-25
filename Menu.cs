using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per vedere tutti i veicoli");
                Console.WriteLine("Premi 2 per vedere tutte le moto");
                Console.WriteLine("Premi 3 per vedere tutte le auto");
                Console.WriteLine("Premi 4 per vedere tutti i pulmini");
                Console.WriteLine("Premi 5 per inserire un nuovo veicolo");
                Console.WriteLine("Premi 6 per vendere un veicolo");
                Console.WriteLine("Premi 0 per uscire");
                Console.WriteLine();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        DealerManager.ShowVehicles();
                        break;
                    case "2":
                        DealerManager.ShowMotocycles();
                        break;
                    case "3":
                        DealerManager.ShowCars();
                        break;
                    case "4":
                        DealerManager.ShowBuses();
                        break;
                    case "5":
                        DealerManager.InsertVehicles();
                        break;
                    case "6":
                        DealerManager.SellVehicle();
                        break;
                    case "0":
                        Console.WriteLine("Ciao alla prossima");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
    }
}
