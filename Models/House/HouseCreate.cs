using System.ComponentModel.DataAnnotations;

namespace HouseViewingMVC.Models.House
{
    public class HouseCreate
    {
        [Required]
        public int Beds { get; set; }
        [Required]
        public double Baths { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        public DateTime ListingDate { get; set; }
    }
}