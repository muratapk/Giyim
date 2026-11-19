using System.ComponentModel.DataAnnotations;

namespace Giyim.Models
{
    public class UrunResmi
    {
        [Key]
        public int Id { get; set; }

        public string ResimYolu { get; set; } = "";

        public bool AnaResimMi { get; set; }

        public int UrunId { get; set; }

        public Urun? Urun { get; set; }
    }
}
