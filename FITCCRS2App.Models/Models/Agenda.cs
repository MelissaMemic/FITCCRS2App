namespace FITCCRS2App.Models.Models
{
	public class Agenda
	{
        public int AgendaId { get; set; }
        public int? Dan { get; set; }
        public int? TakmicenjeId { get; set; }

        public virtual Takmicenje Takmicenje { get; set; }= new ();
    }
}

