using System.ComponentModel.DataAnnotations;

namespace ProjectVsoft.Models
{
    public class UserLoginDetails
    {
        [Key]
        [Required]
        public int UserLoginId {  get; set; }
        [Required]
        public string Password {  get; set; }
        [Required]
        public int UserTypeId {  get; set; }
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
