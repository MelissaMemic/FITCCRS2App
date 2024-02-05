using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Sponzors")]
    public partial class Sponzor
    {
        [Key]
        public int SponzorId { get; set; }
        public string Naziv { get; set; } = null!;
        public int? Godina { get; set; }

        [ForeignKey("Skategorije")]
        public int SkategorijeId { get; set; }
        public virtual Skategorije Skategorije { get; set; } = null!;

        [ForeignKey("Kategorija")]
        public int? KategorijaId { get; set; }
        public virtual Kategorija? Kategorija { get; set; }
    }
}
