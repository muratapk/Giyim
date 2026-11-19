namespace Giyim.Models
{
    public class Renk
    {
        public int Id { get; set; }

        public string RenkAdi { get; set; } = "";

        public string? RenkKodu { get; set; }

        public ICollection<UrunVaryanti> Varyantlar { get; set; }
            = new List<UrunVaryanti>();
    }
}
