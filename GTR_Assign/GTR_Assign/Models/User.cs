using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTR_Assign.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }

    class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }  
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
