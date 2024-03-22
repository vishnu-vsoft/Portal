using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace ProjectVsoft.Models
{
    public class UserDetails
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        
        public string PhoneNumber { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Required]
        public int Status {  get; set; }
        [Required]
        public string Remark { get; set; }
        
        public string? Password { get; set; }
    }
}
