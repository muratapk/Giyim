using Microsoft.EntityFrameworkCore;
using Giyim.Models;
namespace Giyim.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Beden> Bedenler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylari { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunVaryanti> UrunVaryantleri { get; set; }
        public DbSet<UrunYorum> UrunYorumlar { get; set; }
        public DbSet<Renk> Renkler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<SepetUrun> SepetUrunler { get; set; }
        public DbSet<Marka> Markalar { get; set; }



    }
}
