using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class User
    {
        [Key]
        public string QLID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? APM { get; set; }
        public string Role { get; set; }

        [ForeignKey("APM")]
        public virtual User APMUser { get; set; }

        // Navigation properties


    }
}
