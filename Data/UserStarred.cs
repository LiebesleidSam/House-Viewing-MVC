using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseViewingMVC.Data
{
    public class UserStarred
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "House")]
        public virtual int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public virtual House House { get; set; }
        [Display(Name = "User")]
        public virtual int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}