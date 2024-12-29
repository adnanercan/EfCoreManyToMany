using EfCoreManyToMany.FluentApiCozumu;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreManyToMany.GenericRepository.EntityConfig
{
    public class CategoryConfig:BaseConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.CategoryName).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(100);

            builder.HasIndex(p => p.CategoryName).IsUnique(true);
        }
    }
}
