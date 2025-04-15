using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using System.Reflection;

namespace Repositories
{
    public class RepositoryContext : DbContext //veritabanı
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new CategoryConfig());

            //migration ifadeliri otomatik tanımlanır 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
