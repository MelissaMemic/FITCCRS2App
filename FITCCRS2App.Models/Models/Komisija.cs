using FITCCRS2App.Models.Enums;

namespace FITCCRS2App.Models.Models
{
    public class Komisija
	{
        public int KomisijaId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;

        public UlogaKomisija Role { get; set; } = UlogaKomisija.Clan;

        public int? KategorijaId { get; set; }
        public virtual Kategorija? Kategorija { get; set; }
    }
}