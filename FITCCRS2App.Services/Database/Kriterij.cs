using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Kriterijs")]
    public partial class Kriterij
    {
        [Key]
        public int KriterijId { get; set; }
        public string? Naziv { get; set; }
        public string? Vrijednost { get; set; }

        [ForeignKey("Kategorija")]
        public int? KategorijaId { get; set; }
        public virtual Kategorija? Kategorija { get; set; }
    }
}
