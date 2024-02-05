using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FITCCRS2App.Models.Enums;

namespace FITCCRS2App.Services.Database
{
    [Table("Users")]
    public partial class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City? City { get; set; }

        [ForeignKey("Citizenship")]
        public int? CitizenshipId { get; set; }
        public virtual Country? Citizenship { get; set; }

        public string Image { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string WebSite { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        public string Password { get; set; } = string.Empty;

        public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

    }
}
