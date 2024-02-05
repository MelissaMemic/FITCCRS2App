using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FITCCRS2App.Models.Enums;

namespace FITCCRS2App.Services.Database
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public Role Role { get; set; } = Role.Takmicar;
    }
}
