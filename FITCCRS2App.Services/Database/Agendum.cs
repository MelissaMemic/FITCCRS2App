using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Agendums")]
    public partial class Agendum
    {
        public Agendum()
        {
            Dogadjajs = new HashSet<Dogadjaj>();
        }

        [Key]
        public int AgendaId { get; set; }
        public int? Dan { get; set; }

        [ForeignKey("Takmicenje")]
        public int? TakmicenjeId { get; set; }
        public virtual Takmicenje? Takmicenje { get; set; }

        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; } 
    }
}
