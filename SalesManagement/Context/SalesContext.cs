using System.Data.Entity;

namespace SalesManagement
{
    public class SalesContext : DbContext
    {
        public DbSet<M_Division> M_Divisions { get; set; }
        public DbSet<M_Position> M_Potisions { get; set; }
        public DbSet<M_Message> M_Messages { get; set; }
    }    
}
