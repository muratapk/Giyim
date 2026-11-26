using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Giyim.Models
{
    public class UrunResmi
    {
        [Key]
        public int Id { get; set; }

        public string ResimYolu { get; set; } = "";

        public bool AnaResimMi { get; set; }

        public int UrunId { get; set; }

        public virtual Urun? Urun { get; set; }
        [NotMapped]
        //bunu database dosyasına ekleme 
        public IFormFile? PicturePath { get; set; }
    }
}
