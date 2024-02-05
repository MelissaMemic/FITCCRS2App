using System;
namespace FITCCRS2App.Models.Models
{
	public class Projekat
	{

        public int ProjekatId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public int KategorijaId { get; set; }
        public int TimId { get; set; }

        public virtual Kategorija Kategorija { get; set; } = null!;
        public virtual Tim Tim { get; set; } = null!;
        //public virtual ICollection<Rezultat> Rezultats { get; set; }
    }
}

