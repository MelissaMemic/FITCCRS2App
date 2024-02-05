using System;
namespace FITCCRS2App.Models.RequestObjects
{
	public class TakmicenjeUpsertRequest
	{
        public string Naziv { get; set; } = string.Empty;
        public string Slogan { get; set; } = string.Empty;
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public int Godina { get; set; }
        public int BrojDana { get; set; }
        public string Slika { get; set; } = string.Empty;
    }
}

