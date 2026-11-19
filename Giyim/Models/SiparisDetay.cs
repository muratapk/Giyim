using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Giyim.Models
{
    public class SiparisDetay
    {
        [Key]
            public int Id { get; set; }

            public int SiparisId { get; set; }

            public Siparis? Siparis { get; set; }

            public int UrunVaryantiId { get; set; }

            public UrunVaryanti? UrunVaryanti { get; set; }

            public int Adet { get; set; }

            [Precision(18, 2)]
            public decimal BirimFiyat { get; set; }
        
    }
}
