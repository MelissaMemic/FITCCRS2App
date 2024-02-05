using System;
namespace FITCCRS2App.Models.Models
{
	public class Kategorija
	{
        public int KategorijaId { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public int? TakmicenjeId { get; set; }

        public virtual Takmicenje? Takmicenje { get; set; }
    }
}

