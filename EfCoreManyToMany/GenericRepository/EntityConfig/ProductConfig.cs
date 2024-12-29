using EfCoreManyToMany.FluentApiCozumu;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreManyToMany.GenericRepository.EntityConfig
{
    public class ProductConfig:BaseConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.ProductName).HasMaxLength(100);
            
        }
    }
}
