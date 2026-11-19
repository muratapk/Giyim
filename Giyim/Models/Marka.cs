using System.ComponentModel.DataAnnotations;

namespace Giyim.Models
{
    public class Marka
    {
        public class Marka
        {
            public int Id { get; set; }

            [Required, StringLength(100)]
            public string MarkaAdi { get; set; } = "";

            public ICollection<Urun> Urunler { get; set; }
                = new List<Urun>();
        }
    }
}
