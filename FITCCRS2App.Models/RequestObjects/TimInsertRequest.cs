namespace FITCCRS2App.Models.RequestObjects
{
	public class TimInsertRequest
	{
        public int? TimId { get; set; }
        public string? Naziv { get; set; }
        public int? BrojClanova { get; set; }
        public int? TakmicenjeId { get; set; }
    }
}

