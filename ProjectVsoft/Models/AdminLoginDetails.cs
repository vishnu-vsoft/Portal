using System.ComponentModel.DataAnnotations;

namespace ProjectVsoft.Models
{
    public class AdminLoginDetails
    {
        [Key]
        [Required]
        public int AdminLoginId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
