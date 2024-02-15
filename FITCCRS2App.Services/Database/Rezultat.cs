using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Rezultats")]
    public partial class Rezultat
    {
        [Key]
        public int RezultatId { get; set; }
        public string Napomena { get; set; } 
        public int Bod { get; set; }

        [ForeignKey("Projekat")]
        public int? ProjekatId { get; set; }
        public virtual Projekat? Projekat { get; set; } 
    }
}
