using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Giyim.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UrunAdi { get; set; } = "";

        public string? Aciklama { get; set; }

        [Precision(18, 2)]
        public decimal Fiyat { get; set; }

        [Precision(18, 2)]
        public decimal? IndirimliFiyat { get; set; }

        public bool AktifMi { get; set; } = true;

        public DateTime EklenmeTarihi { get; set; }
            = DateTime.Now;

        // Kategori ilişkisi
        public int KategoriId { get; set; }

        public Kategori? Kategori { get; set; }

        // Marka ilişkisi
        public int MarkaId { get; set; }

        public Marka? Marka { get; set; }

        // Ürün resimleri
        public ICollection<UrunResmi> UrunResimleri { get; set; }
            = new List<UrunResmi>();

        // Beden ve renk varyantları
        public ICollection<UrunVaryanti> Varyantlar { get; set; }
            = new List<UrunVaryanti>();

        // Ürün yorumları
        public ICollection<UrunYorum> Yorumlar { get; set; }
            = new List<UrunYorum>();
    }
}

