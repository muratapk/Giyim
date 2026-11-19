using System.ComponentModel.DataAnnotations;

namespace Giyim.Models
{
    public class Sepet
    {
        [Key]
        public int Id { get; set; }

        public string? KullaniciId { get; set; } = "";

       

        public DateTime ? OlusturmaTarihi { get; set; }
            = DateTime.Now;

        public ICollection<SepetUrun> SepetUrunleri { get; set; }
            = new List<SepetUrun>();
    }
}
