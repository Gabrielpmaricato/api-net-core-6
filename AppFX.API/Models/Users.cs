using System.ComponentModel.DataAnnotations;

namespace AppFX.API.Models
{
    public class Users
    {
        [Key]
        public int IDUser { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
