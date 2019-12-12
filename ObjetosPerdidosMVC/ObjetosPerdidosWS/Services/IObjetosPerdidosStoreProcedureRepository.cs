using ObjetosPerdidosWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjetosPerdidosWS.Services
{
    public interface IObjetosPerdidosRepository : IDisposable
    {
        List<TaxiobjetosPerdidos> GetObjetosPerdidos(string objeto);
    }
}
