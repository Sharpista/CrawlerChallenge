using API.Data.Configurations;
using API.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<ServidorProxy> Servidores { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ServidorProxyConfiguration());
        }
    }
}
