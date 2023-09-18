using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseViewingMVC.Data
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "House")]
        public virtual int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public virtual House House { get; set; }
        [Display(Name = "School")]
        public virtual int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual School School { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
    }
}