using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Skategorijes")]
    public partial class Skategorije
    {
        public Skategorije()
        {
            Sponzors = new HashSet<Sponzor>();
        }
        [Key]
        public int SkategorijeId { get; set; }
        public string Naziv { get; set; } = null!;
        public int? Iznos { get; set; }

        public virtual ICollection<Sponzor> Sponzors { get; set; }
    }
}
