using System.ComponentModel.DataAnnotations;

namespace Giyim.Models
{
    public class Beden
    {
        [Key]
        public int Id { get; set; }

        public string BedenAdi { get; set; } = "";

        public ICollection<UrunVaryanti> Varyantlar { get; set; }
            = new List<UrunVaryanti>();
    }
}
