using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using ObjetosPerdidosWS.Models;
using ObjetosPerdidosWS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ObjetosPerdidosWS.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DB_ObjetosPerdidosContext _context { get; set; }
        protected DbSet<T> _entity { get; set; }
        public RepositoryBase()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("databaseConnection");
            try
            {
                var options = new DbContextOptionsBuilder<DB_ObjetosPerdidosContext>()
                    .UseSqlServer(connectionString)
                    .Options;
                 _context = new DB_ObjetosPerdidosContext(options);
                 _entity = _context.Set<T>();
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetLogger("fileLogger");
                logger.Error(ex, "Error no controlado");
            }
        }        
        public List<T> ExecuteStoreProcedure (DbSet<T> table, string storeProcedureName, params object[] parameters)
        {
            
            for (int i = 0; i< parameters.Length; i++)
            {
                storeProcedureName = storeProcedureName +" {"+i+"}";
            }
            try
            {
                return table.FromSqlRaw(storeProcedureName, parameters).ToList();
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetLogger("fileLogger");
                logger.Error(ex, "Error no controlado");
                return null;
            }
        }

        public void Dispose(){}
    }
}
