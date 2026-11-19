using System.ComponentModel.DataAnnotations;

namespace Giyim.Models
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }

        public string? AdresBasligi { get; set; } = "";

        public string? AdSoyad { get; set; } = "";
        
        public string? Telefon { get; set; } = "";

        public string? Sehir { get; set; } = "";

        public string? Ilce { get; set; } = "";

        public string? AcikAdres { get; set; } = "";

        public string? KullaniciId { get; set; } = "";

        
    }
}
