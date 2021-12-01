using CatalogService.DAL.EFConfig;
using CatelogService.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModernECommerce.Common.Constants;
using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.DAL.EF
{
    public class CatalogServiceDbContext : DbContext 
    {
        private IConfiguration _config;

        public CatalogServiceDbContext(IConfiguration configRoot)
        {
            _config = configRoot;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuration.GetConnectionString()
            //optionsBuilder.UseSqlServer("Data Source=ecomdb-vm.database.windows.net;Initial Catalog=ecomdb;User ID=akumaramar;Password=RameshPandit17@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
            optionsBuilder.UseSqlServer(_config[GlobalConstants.CONNECTIONSTRING]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create instance to load assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityTypeConfiguration).Assembly);
            //modelBuilder.Entity<TEntity>().ToTable("Products");
        }
    }
}
