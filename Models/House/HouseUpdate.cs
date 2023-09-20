

namespace HouseViewingMVC.Models.House
{
    public class HouseUpdate
    {
        public int Id { get; set; }
        public int Beds { get; set; }
        public double Baths { get; set; }
        public string? Description { get; set; }
        public DateTime ListingDate { get; set; } 
    }
}