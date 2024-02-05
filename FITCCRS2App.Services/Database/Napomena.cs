using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Napomenas")]
    public partial class Napomena
    {
        [Key]
        public int NapomenaId { get; set; }
        public string? Poruka { get; set; }
        public string? UsernameTakmicar { get; set; }
        public string? UserName { get; set; }
    }
}
