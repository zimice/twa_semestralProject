

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ppt.Api
{
    public class User : IEquatable<User>
    {

        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Equals(User? other)
        {
            return this.Username == other.Username && this.Password == other.Password;
        }
    }
}
