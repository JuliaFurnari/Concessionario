using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.Interfaces
{
    interface IDbManager<T>
    {
        public List<T> Fetch();
        public T GetById(int? id);
        public void Insert(T t);
        public void Delete(T t);
        public void Update(T t);

    }
}
