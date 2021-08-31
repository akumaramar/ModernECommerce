using CatalogService.DAL.EFConfig;
using CatelogService.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuration.GetConnectionString()
            //optionsBuilder.UseSqlServer("Data Source=ecomdb-vm.database.windows.net;Initial Catalog=ecomdb;User ID=akumaramar;Password=RameshPandit17@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //base.OnConfiguring(optionsBuilder);

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "APT04-4ZNCLH2";
            connectionStringBuilder.UserID = "sa";
            connectionStringBuilder.Password = "Ramesh17@";
            connectionStringBuilder.InitialCatalog = "catalogdb";

            optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create instance to load assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityTypeConfiguration).Assembly);
            //modelBuilder.Entity<TEntity>().ToTable("Products");
        }
    }
}
