using GRPC_Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace GRPC_Service.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MySqlConnection"));
        }

        public DbSet<Person> Persons { get; set; }
    }
}
