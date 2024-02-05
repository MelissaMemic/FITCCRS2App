using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Predavacs")]
    public partial class Predavac
    {
        [Key]
        public int PredavacId { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Ustanova { get; set; }
        public string? Zvanje { get; set; }
        public string? Email { get; set; }
    }
}
