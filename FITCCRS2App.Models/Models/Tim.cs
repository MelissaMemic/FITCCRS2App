using System;
namespace FITCCRS2App.Models.Models
{
	public class Tim
	{
        public int TimId { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public int? BrojClanova { get; set; }
        public int? TakmicenjeId { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; } = string.Empty;

        public virtual Takmicenje Takmicenje { get; set; } = new();
    }
}

