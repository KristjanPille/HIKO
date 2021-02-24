using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1.Identity
{
    public class RegisterDTO
    {
        [MaxLength(256)]
        [EmailAddress]
        [Required]
        public string Email { get; set; } = default!;
        
        [MinLength(6)]
        [MaxLength(100)]
        [Required]
        public string Password { get; set; } = default!;
        
        
        [MinLength(1)]
        [MaxLength(128)]
        [Required]
        public string FirstName { get; set; } = default!;
        
        [MinLength(1)]
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; } = default!;
        
        [MinLength(1)]
        [MaxLength(20)]
        [Required]
        public string PhoneNumber { get; set; } = default!;
        
        [MinLength(1)]
        [MaxLength(128)]
        [Required]
        public string Model { get; set; } = default!;
        
        [MinLength(1)]
        [MaxLength(128)]
        [Required]
        public string Mark { get; set; } = default!;
        
        public int CarSize { get; set; } = default!;
    }
}