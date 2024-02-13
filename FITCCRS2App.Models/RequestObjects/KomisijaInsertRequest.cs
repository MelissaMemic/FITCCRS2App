using FITCCRS2App.Models.Enums;

namespace FITCCRS2App.Models.RequestObjects
{
    public class KomisijaInsertRequest
    {
        public string? Ime { get; set; } 
        public string? Prezime { get; set; }
        public string? Email { get; set; } 
        public UlogaKomisija Role { get; set; }
        public int? KategorijaId { get; set; }
    }
}

