using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ObjetosPerdidosWS.Models
{
    public partial class DB_ObjetosPerdidosContext : DbContext
    {
        public DB_ObjetosPerdidosContext()
        {            
        }
        private readonly string connectionString;
        public DB_ObjetosPerdidosContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DB_ObjetosPerdidosContext(DbContextOptions<DB_ObjetosPerdidosContext> options)
            : base(options)
        {

        }
        public virtual DbSet<TaxiobjetosPerdidos> TaxiobjetosPerdidos { get; set; }

    }
}
