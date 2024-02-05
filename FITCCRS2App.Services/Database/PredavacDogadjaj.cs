using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("PredavacDogadjajs")]
    public partial class PredavacDogadjaj
    {
        [ForeignKey("Dogadjaj")]
        public int DogadjajId { get; set; }
        public virtual Dogadjaj Dogadjaj { get; set; }

        [ForeignKey("Predavac")]
        public int PredavacId { get; set; }
        public virtual Predavac Predavac { get; set; }
    }
}