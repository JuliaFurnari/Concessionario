using Concessionario.Entities;
using Concessionario.Interfaces;
using System;
using System.Collections.Generic;

namespace Concessionario.ListRepository
{
    public class MotocycleListRepository : IMotocycleDbManager
    {
        public static List<Motocycle> motocycles = new List<Motocycle>
        {
            new Motocycle("Honda", "CB", 2020, null),
            new Motocycle("Honda", "SH", 2015, null),
            new Motocycle("Ducati", "Panigale", 2021, null)
        };


        public void Delete(Motocycle motocycle)
        {
            motocycles.Remove(motocycle);
        }

        public List<Motocycle> Fetch()
        {
            return motocycles;
        }

        public Motocycle GetById(int? id)
        {
            return motocycles.Find(m => m.Id == id);

            //foreach(var motocycle in motocycles)
            //{
            //    if(motocycle.Id == id)
            //    {
            //        return motocycle;
            //    }
            //}
        }

        public void Insert(Motocycle motocycle)
        {
            motocycles.Add(motocycle);
        }

        public void Update(Motocycle motocycle)
        {
            // moto vecchia, con i vecchi parametri
            var motoDaCancellare = GetById(motocycle.Id);

            Delete(motoDaCancellare);

            //Moto con i nuovi parametri
            Insert(motocycle);
        }
    }
}
