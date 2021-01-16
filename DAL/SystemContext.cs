using TicketFinalSys.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TicketFinalSys.DAL
{
    public class SystemContext : DbContext
    {

        public SystemContext() : base("SystemContext")
        { }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}