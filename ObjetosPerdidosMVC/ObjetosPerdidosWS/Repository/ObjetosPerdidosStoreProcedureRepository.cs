using Microsoft.EntityFrameworkCore;
using ObjetosPerdidosWS.Models;
using ObjetosPerdidosWS.Repository;
using ObjetosPerdidosWS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjetosPerdidosWS
{
    public class ObjetosPerdidosRepository : RepositoryBase<TaxiobjetosPerdidos>, IObjetosPerdidosRepository
    {
        public ObjetosPerdidosRepository()
            : base()
        {           
        }

        public List<TaxiobjetosPerdidos> GetObjetosPerdidos(string objeto)
        {
            return ExecuteStoreProcedure(_entity, "sp_GetObjetosPerdidos", objeto);
        }
    }
}
