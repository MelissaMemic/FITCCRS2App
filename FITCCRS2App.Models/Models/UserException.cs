using System;
namespace FITCCRS2App.Models.Models
{
	public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }
}