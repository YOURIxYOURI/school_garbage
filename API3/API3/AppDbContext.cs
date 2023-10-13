using Microsoft.EntityFrameworkCore;

namespace API3
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Ksiazka> Ksiazka { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var serverversion = new MySqlServerVersion(new Version(1,1,0));
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DBConnection"), serverversion).UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
