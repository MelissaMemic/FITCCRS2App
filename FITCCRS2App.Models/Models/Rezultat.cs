using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Models.Models
{
	public class Rezultat
	{
        public int RezultatId { get; set; }
        public string Napomena { get; set; }
        public int Bod { get; set; }

        public int ProjekatId { get; set; }
        public virtual Projekat Projekat { get; set; } = null!;

    }
}

