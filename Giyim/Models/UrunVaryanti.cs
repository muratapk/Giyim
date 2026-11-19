namespace Giyim.Models
{
    public class UrunVaryanti
    {
        public int Id { get; set; }

        public string? StokKodu { get; set; }

        public int StokMiktari { get; set; }

        public int UrunId { get; set; }

        public Urun? Urun { get; set; }

        public int BedenId { get; set; }

        public Beden? Beden { get; set; }

        public int RenkId { get; set; }

        public Renk? Renk { get; set; }
    }
}
