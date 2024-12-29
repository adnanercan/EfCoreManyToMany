using EfCoreManyToMany.FluentApiCozumu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EfCoreManyToMany.GenericRepository.EntityConfig
{
    public class CategoryProductConfig : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(p => new { p.ProductId, p.CategoryId });

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.Product)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(p => p.ProductId);

        }
    }
}
