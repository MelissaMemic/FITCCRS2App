namespace FITCCRS2App.Models.RequestObjects
{
    public class DogadjajInsertRequest
	{
        public string? Naziv { get; set; }
        public int? Trajanje { get; set; }
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public string? Napomena { get; set; }
        public string? Lokacija { get; set; }

        public int? AgendaId { get; set; }
    }
}

