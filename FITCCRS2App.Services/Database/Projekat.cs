using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Projekats")]
    public partial class Projekat
    {
        public Projekat()
        {
            Rezultats = new HashSet<Rezultat>();
        }
        [Key]
        public int ProjekatId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
        [ForeignKey("Kategorija")]
        public int KategorijaId { get; set; }
        public virtual Kategorija Kategorija { get; set; } = null!;

        [ForeignKey("Tim")]
        public int TimId { get; set; }
        public virtual Tim Tim { get; set; } = null!;

        public virtual ICollection<Rezultat> Rezultats { get; set; }
    }
}
