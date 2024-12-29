using EfCoreManyToMany.GenericRepository.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreManyToMany.FluentApiCozumu
{


    public class Kitap
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }

        public ICollection<KitapYazar> Yazarlar { get; set; } = new List<KitapYazar>();
    }
    public class Yazar
    {
        public int Id { get; set; }
        public string YazarAdi { get; set; }

        public ICollection<KitapYazar> Kitaplar { get; set; } = new List<KitapYazar>();
    }

    //Cross table manuel oluşturulmalı
    //DbSet olarak eklenmesine lüzum yok, 
    //Composite PK Haskey metodu ile kurulmalı!

    //Cross Table
    public class KitapYazar
    {
        public int KitapId { get; set; }
        public int YazarId { get; set; }

        public Kitap Kitap { get; set; }
        public Yazar Yazar { get; set; }
    }

    public class FluentApiDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AManyToManySample;Trusted_Connection=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KitapYazar>()
          .HasKey(ky => new { ky.KitapId, ky.YazarId });

            modelBuilder.Entity<KitapYazar>()
                .HasOne(ky => ky.Kitap)
                .WithMany(k=>k.Yazarlar)
                .HasForeignKey(ky => ky.KitapId);

            modelBuilder.Entity<KitapYazar>()
                .HasOne(ky => ky.Yazar)
                .WithMany(y => y.Kitaplar)
                .HasForeignKey(ky => ky.YazarId);

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryProductConfig());

           

        }
    }
}
