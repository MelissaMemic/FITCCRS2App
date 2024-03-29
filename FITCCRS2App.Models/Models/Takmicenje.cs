﻿namespace FITCCRS2App.Models.Models
{
	public class Takmicenje
	{
        public int TakmicenjeId { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Slogan { get; set; } = string.Empty;
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public int? Godina { get; set; }
        public int? BrojDana { get; set; }
        public string Slika { get; set; } = string.Empty;

        //public virtual ICollection<Agenda> Agenda { get; set; }
        //public virtual ICollection<Tim> Tims { get; set; }
    }
}

