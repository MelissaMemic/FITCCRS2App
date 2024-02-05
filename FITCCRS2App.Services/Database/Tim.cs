using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Tims")]
    public partial class Tim
    {
        public Tim()
        {
            Projekats = new HashSet<Projekat>();
        }
        [Key]
        public int TimId { get; set; }
        public string Naziv { get; set; } = null!;
        public int BrojClanova { get; set; }

        [ForeignKey("Takmicenje")]
        public int TakmicenjeId { get; set; }
        public virtual Takmicenje Takmicenje { get; set; } = null!;
        public virtual ICollection<Projekat> Projekats { get; set; }
    }
}
