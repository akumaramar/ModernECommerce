using CatelogService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.DAL.EFConfig
{
    public class CatalogEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrandModel>
    {
        public void Configure(EntityTypeBuilder<CatalogBrandModel> builder)
        {
            builder.ToTable("CatalogBrand");
        }
    }
}
