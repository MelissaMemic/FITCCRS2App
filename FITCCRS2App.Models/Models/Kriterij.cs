namespace FITCCRS2App.Models.Models
{
    public class Kriterij
	{
        public int KriterijId { get; set; }
        public string? Naziv { get; set; }
        public string? Vrijednost { get; set; }

        public int? KategorijaId { get; set; }
        public virtual Kategorija? Kategorija { get; set; }
    }
}

