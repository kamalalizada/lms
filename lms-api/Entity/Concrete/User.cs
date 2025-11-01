using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete
{


    public class User
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; } = "Student";

        [NotMapped]
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}


