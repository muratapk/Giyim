using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Giyim.Models
{
    public class Siparis
    {
        [Key]
        public int Id { get; set; }

        public string? SiparisNo { get; set; } = "";

        public DateTime ? SiparisTarihi { get; set; }
            = DateTime.Now;

        [Precision(18, 2)]
        public decimal ? ToplamTutar { get; set; }

        public string ? SiparisDurumu { get; set; } = "Bekliyor";

        public string? KullaniciId { get; set; } = "";

       

        public int? AdresId { get; set; }

        public Adres? Adres { get; set; }

        // Sipariş anındaki adres bilgileri
        public string TeslimatAdresi { get; set; } = "";

        public ICollection<SiparisDetay> SiparisDetaylari { get; set; }
            = new List<SiparisDetay>();
    }
}
