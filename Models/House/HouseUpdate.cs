using System.ComponentModel.DataAnnotations;

namespace HouseViewingMVC.Models.House
{
    public class HouseUpdate
    {
        public int Id { get; set; }
        [Required]
        public int Beds { get; set; }
        [Required]
        public double Baths { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Description { get; set; }
        public DateTime ListingDate { get; set; } 
    }
}