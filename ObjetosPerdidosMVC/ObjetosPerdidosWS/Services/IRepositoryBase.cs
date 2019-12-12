using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ObjetosPerdidosWS.Services
{
    public interface IRepositoryBase<T> : IDisposable
        where T : class
    {
        List<T> ExecuteStoreProcedure(DbSet<T> table, string storeProcedureName, params object[] parameters);
    }
}
