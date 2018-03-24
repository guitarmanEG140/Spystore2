using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Domain.Entities;


namespace Repository.EF
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {
        }
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //mssqllocaldb;
                optionsBuilder.UseSqlServer(
                //  Data Source = SHREVE01; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False
                @"Server=SHREVE01;Database=SpyStore;Trusted_Connection=True;MultipleActive
                ResultSets=true;", options => options.ExecutionStrategy(c => new MyExecutionStrategy(c)));
            }
        }
    }
}