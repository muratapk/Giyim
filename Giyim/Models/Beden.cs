namespace Giyim.Models
{
    public class Beden
    {
        public int Id { get; set; }

        public string BedenAdi { get; set; } = "";

        public ICollection<UrunVaryanti> Varyantlar { get; set; }
            = new List<UrunVaryanti>();
    }
}
