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
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("Products");
        }
    }
}
