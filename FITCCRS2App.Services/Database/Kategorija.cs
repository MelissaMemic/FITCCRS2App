using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Kategorijas")]
    public partial class Kategorija
    {
        public Kategorija()
        {
            Komisijas = new HashSet<Komisija>();
            Kriterijs = new HashSet<Kriterij>();
            Projekats = new HashSet<Projekat>();
            Sponzors = new HashSet<Sponzor>();
        }
        [Key]
        public int KategorijaId { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }

        [ForeignKey("Takmicenje")]
        public int? TakmicenjeId { get; set; }
        public virtual Takmicenje? Takmicenje { get; set; }
        public virtual ICollection<Komisija> Komisijas { get; set; }
        public virtual ICollection<Kriterij> Kriterijs { get; set; }
        public virtual ICollection<Projekat> Projekats { get; set; }
        public virtual ICollection<Sponzor> Sponzors { get; set; }
    }
}
