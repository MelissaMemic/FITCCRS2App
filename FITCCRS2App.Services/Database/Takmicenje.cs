
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Takmicenjes")]
    public partial class Takmicenje
    {
        public Takmicenje()
        {
            Agenda = new HashSet<Agendum>();
            Kategorijas = new HashSet<Kategorija>();
            Tims = new HashSet<Tim>();
        }
        [Key]
        public int TakmicenjeId { get; set; }
        public string? Naziv { get; set; }
        public string? Slogan { get; set; }
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public int? Godina { get; set; }
        public int? BrojDana { get; set; }
        public string? Slika { get; set; }

        public virtual ICollection<Agendum> Agenda { get; set; }
        public virtual ICollection<Kategorija> Kategorijas { get; set; }
        public virtual ICollection<Tim> Tims { get; set; }
    }
}
