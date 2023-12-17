using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class Employee
    {
        [Key]
        public string QLID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string APM { get; set; }


        [ForeignKey("APM")]
        public virtual Employee APMUser { get; set; }

    }
}
