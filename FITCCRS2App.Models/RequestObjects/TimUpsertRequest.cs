namespace FITCCRS2App.Models.RequestObjects
{
    public class TimUpsertRequest
	{
        public int? TimId { get; set; }
        public string? Naziv { get; set; } = null!;
        public int? BrojClanova { get; set; }
        public int? TakmicenjeId { get; set; }
    }
}