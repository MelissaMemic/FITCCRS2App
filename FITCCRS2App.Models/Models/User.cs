using FITCCRS2App.Models.Enums;

namespace FITCCRS2App.Models.Models
{
	public class User
	{
        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public City? City { get; set; } = new();

        public Country? Citizenship { get; set; } = new();

        public string Image { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        public List<Role> Roles { get; set; } = new();

    }
}

