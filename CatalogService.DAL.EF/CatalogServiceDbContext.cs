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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.DAL.EF
{
    public class CatalogServiceDbContext : DbContext 
    {
        private IConfiguration _config;


        public CatalogServiceDbContext([NotNullAttribute] DbContextOptions options, bool dummy): base(options)
        {

        }

        public CatalogServiceDbContext(IConfiguration configRoot)
        {
            _config = configRoot;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Use below line to generate DB
            //SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder();
            //sqlConnection.DataSource = "APT04-4ZNCLH2";
            //sqlConnection.UserID = "sa";
            //sqlConnection.Password = "Ramesh17@";
            //sqlConnection.InitialCatalog = "catalogdb";
            //Configuration.GetConnectionString().
            //optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);


            // Need to run as it will required for Database updrades.
            //optionsBuilder.UseSqlServer()
            //optionsBuilder.UseSqlServer("Data Source=ecomdb-vm.database.windows.net;Initial Catalog=ecomdb;User ID=akumaramar;Password=RameshPandit17@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseSqlServer(sqlConnection.ToString());
            base.OnConfiguring(optionsBuilder);


            // TODO: Remove after use
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
