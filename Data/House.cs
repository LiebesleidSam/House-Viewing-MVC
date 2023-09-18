using System.ComponentModel.DataAnnotations;

namespace HouseViewingMVC.Data
{
    public class House
    {
        [Key]
        public int Id { get; set; }
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