using System.ComponentModel.DataAnnotations;

namespace HouseViewingMVC.Data
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}