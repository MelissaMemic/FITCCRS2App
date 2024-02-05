using System;
using System.Diagnostics.Metrics;

namespace FITCCRS2App.Models.Models
{
	public class City
	{
        public int CityId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public Country Country { get; set; } = new();

    }
}

