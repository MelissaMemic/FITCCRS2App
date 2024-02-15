using FITCCRS2App.Models.Enums;

namespace FITCCRS2App.Models.Models
{
	public class User
	{
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        //public City? City { get; set; } 

        //public Country? Citizenship { get; set; } 

        public string Image { get; set; } 
        public string WebSite { get; set; }

        public string Email { get; set; } 

        public string Phone { get; set; } 

        public DateTime CreateDate { get; set; }

        public List<Role> Roles { get; set; } 

    }
}

