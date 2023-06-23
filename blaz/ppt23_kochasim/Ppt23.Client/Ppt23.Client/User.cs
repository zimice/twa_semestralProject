

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ppt23.Client
{
    public class User
    {

        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } 
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
