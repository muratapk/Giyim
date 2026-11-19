namespace Giyim.Models
{
    public class Sepet
    {
        public int Id { get; set; }

        public string KullaniciId { get; set; } = "";

        public ApplicationUser? Kullanici { get; set; }

        public DateTime OlusturmaTarihi { get; set; }
            = DateTime.Now;

        public ICollection<SepetUrun> SepetUrunleri { get; set; }
            = new List<SepetUrun>();
    }
}
