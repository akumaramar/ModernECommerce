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
    public class ProductTypeEntityTypeConfiguration : IEntityTypeConfiguration<ProductTypeModel>
    {
        public void Configure(EntityTypeBuilder<ProductTypeModel> builder)
        {
            builder.ToTable("ProductType");
        }
    }
}
