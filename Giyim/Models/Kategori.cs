using System.ComponentModel.DataAnnotations;

namespace Giyim.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Kategori adı boş geçilemez.")]
        public string KategoriAdi { get; set; } = "";

        public int? UstKategoriId { get; set; }

        public Kategori? UstKategori { get; set; }

        public ICollection<Kategori> AltKategoriler { get; set; }
            = new List<Kategori>();

        public ICollection<Urun> Urunler { get; set; }
            = new List<Urun>();
    }
}
