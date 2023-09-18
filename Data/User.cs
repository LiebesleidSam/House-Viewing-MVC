using System.ComponentModel.DataAnnotations;

namespace HouseViewingMVC.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
    }
}