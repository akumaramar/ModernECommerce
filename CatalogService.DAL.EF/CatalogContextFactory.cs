using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.DAL.EF
{
    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogServiceDbContext>
    {
        public CatalogServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogServiceDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=catalogdb;User ID=sa;Password=Ramesh17@");

            return new CatalogServiceDbContext(optionsBuilder.Options, true);
        }
    }
}
