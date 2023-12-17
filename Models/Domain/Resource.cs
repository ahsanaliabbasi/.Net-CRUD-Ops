using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Domain
{
    public class Resource
    {
        [Key]
        public string QLID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string APM { get; set; }
        public string Role { get; set; }

        [ForeignKey(nameof(APM))]
        public virtual Resource APMName { get; set; }
    }
}
