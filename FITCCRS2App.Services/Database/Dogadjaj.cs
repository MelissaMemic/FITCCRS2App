using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Dogadjajs")]
    public partial class Dogadjaj
    {
        [Key]
        public int DogadjajId { get; set; }
        public string? Naziv { get; set; }
        public int? Trajanje { get; set; }
        public DateTime? Pocetak { get; set; }
        public DateTime? Kraj { get; set; }
        public string? Napomena { get; set; }
        public string? Lokacija { get; set; }

        [ForeignKey("Agenda")]
        public int? AgendaId { get; set; }
        public virtual Agendum? Agenda { get; set; }
    }
}