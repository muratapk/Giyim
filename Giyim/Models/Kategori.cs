using System.ComponentModel.DataAnnotations;

namespace Giyim.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string KategoriAdi { get; set; } = "";

        public int? UstKategoriId { get; set; }

        public Kategori? UstKategori { get; set; }

        public ICollection<Kategori> AltKategoriler { get; set; }
            = new List<Kategori>();

        public ICollection<Urun> Urunler { get; set; }
            = new List<Urun>();
    }
}
