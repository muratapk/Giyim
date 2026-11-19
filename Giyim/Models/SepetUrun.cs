using System.ComponentModel.DataAnnotations;

namespace Giyim.Models
{
    public class SepetUrun
    {
        [Key]
        public int Id { get; set; }

        public int ?SepetId { get; set; }

        public Sepet? Sepet { get; set; }

        public int ?UrunVaryantiId { get; set; }

        public UrunVaryanti? UrunVaryanti { get; set; }

        public int? Adet { get; set; }
    }
}
