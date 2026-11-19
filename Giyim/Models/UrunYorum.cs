namespace Giyim.Models
{
    public class UrunYorum
    {
        public int Id { get; set; }

        public string Yorum { get; set; } = "";

        public int Puan { get; set; }

        public DateTime YorumTarihi { get; set; }
            = DateTime.Now;

        public int UrunId { get; set; }

        public Urun? Urun { get; set; }

        public string KullaniciId { get; set; } = "";

        public ApplicationUser? Kullanici { get; set; }
    }
}
