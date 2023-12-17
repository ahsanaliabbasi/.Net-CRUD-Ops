using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class CreateUserDTO
    {
        [MinLength(8,ErrorMessage ="QLID can be minimum of 8 charcters")]
        [MaxLength(8, ErrorMessage ="QLID can be maximum of 8 characters")]
        [Required]
        public string QLID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        [Required]
        public string Email { get; set; }
        public string Password { get; set; }

        public string? APM { get; set; }
        public string Role { get; set; }
    }
}
