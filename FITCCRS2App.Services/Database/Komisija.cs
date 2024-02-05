using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FITCCRS2App.Models.Enums;

namespace FITCCRS2App.Services.Database
{
    [Table("Komisijas")]
    public partial class Komisija
    {
        [Key]
        public int KomisijaId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;

        public UlogaKomisija Role { get; set; } = UlogaKomisija.Clan;

        [ForeignKey("Kategorija")]
        public int? KategorijaId { get; set; }
        public virtual Kategorija? Kategorija { get; set; }
    }
}
