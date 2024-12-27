using EfCoreManyToMany.FluentApiCozumu;
using Microsoft.EntityFrameworkCore;

namespace EfCoreManyToMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Default Convention

            //#region Kitap ve yazarin ilk olarak olusturulmasi 
            //EKitapDbContext context = new EKitapDbContext();
            ////Kitap k1 = new Kitap() { KitapAdi = "A Kitap " };
            ////Kitap k2 = new Kitap() { KitapAdi = "B Kitap " };
            ////Kitap k3 = new Kitap() { KitapAdi = "C Kitap " };
            ////Yazar yazar = new Yazar { YazarAdi = "Cemal Sureya" };
            ////yazar.Kitaplar = new List<Kitap>();

            ////context.Yazarlar.Add(yazar);
            ////context.SaveChanges(); 
            //#endregion

            //#region Var olan kitabin yazara eklenmesi
            //var kitap1 = context.Kitaplar.Find(2);
            //var yazar = context.Yazarlar.Find(2);
            //yazar.Kitaplar.Add(kitap1);
            //context.SaveChanges();
            //#endregion 
            #endregion
            #region Fluent Api ile 

            FluentApiDbContext context = new FluentApiDbContext();
            #region Yeni Kayit olusturma
            //var yazar = new Yazar { YazarAdi = "Yasar  Kemal" };
            //var kitap = new Kitap { KitapAdi = "Ince Memed" };
            //yazar.Kitaplar.Add(new KitapYazar { Kitap = kitap });
            //context.Yazarlar.Add(yazar);
            //context.SaveChanges();


            #endregion

            #region Var olan yazara yeni bir kitap eklenmesi
            //var yazar = context.Yazarlar.Include(p => p.Kitaplar).FirstOrDefault(p => p.Id == 2); 
            //Kitap kitap = new Kitap { KitapAdi = "Akcasazin Agalari" };
            //yazar.Kitaplar.Add(new KitapYazar { Kitap = kitap });
            //context.SaveChanges();
            #endregion

            #region Yazara  var olan bir kaydin eklenemsi

            //var yazar = context.Yazarlar.Include(p => p.Kitaplar).FirstOrDefault(p => p.Id == 2);

            //var kitap = context.Kitaplar.FirstOrDefault(p => p.KitapAdi == "C kitap");

            //yazar.Kitaplar.Add(new KitapYazar { Kitap = kitap });

            //context.SaveChanges();
            #endregion


            #region Yazardan kaydin 3 numarali  kitabinin silinmesi
            var yazar = context.Yazarlar.Include(p => p.Kitaplar).FirstOrDefault(p => p.Id == 2);
            var kitap = context.Kitaplar.FirstOrDefault(p => p.Id == 3);

            //var kitapYazar = new KitapYazar { Kitap = kitap };
            var silinecekYazar = yazar.Kitaplar.FirstOrDefault(p => p.KitapId == kitap.Id);
            yazar.Kitaplar.Remove(silinecekYazar);
            context.SaveChanges();
            #endregion
            #endregion

            Console.WriteLine("Hello, World!");
        }
    }

    #region Default Convention
    //İki entity arasındaki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız.
    //(ICollection, List)
    //Default Convention'da cross table'ı manuel oluşturmak zorunda değiliz.
    //EF Core tasarıma uygun bir şekilde cross table'ı kendisi otomatik basacak ve generate edecektir.
    //Ve oluşturulan cross table'ın içerisinde composite primary key'i de otomatik oluşturmuş olacaktır.
    //public class Kitap
    //{
    //    public int Id { get; set; }
    //    public string KitapAdi { get; set; }

    //    public ICollection<Yazar> Yazarlar { get; set; } = new List<Yazar>();
    //}
    //public class Yazar
    //{
    //    public int Id { get; set; }
    //    public string YazarAdi { get; set; }

    //    public ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
    //}
    //#endregion
    //public class EKitapDbContext : DbContext
    //{
    //    public DbSet<Kitap> Kitaplar { get; set; }
    //    public DbSet<Yazar> Yazarlar { get; set; }
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer("Server=.;Database=AManyToManySample;Trusted_Connection=true;TrustServerCertificate=true");
    //    }
    //    //Data Annotations
    //    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    //{
    //    //    modelBuilder.Entity<KitapYazar>()
    //    //        .HasKey(ky => new { ky.KId, ky.YId });
    //    //}

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        //modelBuilder.Entity<KitapYazar>()
    //        //    .HasKey(ky => new { ky.KitapId, ky.YazarId });

    //        //modelBuilder.Entity<KitapYazar>()
    //        //    .HasOne(ky => ky.Kitap)
    //        //    .WithMany(k => k.Yazarlar)
    //        //    .HasForeignKey(ky => ky.KitapId);

    //        //modelBuilder.Entity<KitapYazar>()
    //        //    .HasOne(ky => ky.Yazar)
    //        //    .WithMany(y => y.Kitaplar)
    //        //    .HasForeignKey(ky => ky.YazarId);
    //    }
    //}
    #endregion
}