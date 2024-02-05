using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FITCCRS2App.Services.Database
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; } = string.Empty;

        // Relations
        public virtual ICollection<City> Cities { get; set; } = new List<City>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}

