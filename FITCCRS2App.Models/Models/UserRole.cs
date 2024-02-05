using System;
using FITCCRS2App.Models.Enums;

namespace FITCCRS2App.Models.Models
{
	public class UserRole
	{
        public int Id { get; set; }

        public User User { get; set; } = new();

        public Role Role { get; set; } = Role.Takmicar;
    }
}

