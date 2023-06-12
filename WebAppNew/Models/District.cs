using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppNew.Models
{
    [Table("District")]
    public class District
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string? DistrictName { get; set; }
        [Required]
        public string? CountryName { get; set; }
    }
}
