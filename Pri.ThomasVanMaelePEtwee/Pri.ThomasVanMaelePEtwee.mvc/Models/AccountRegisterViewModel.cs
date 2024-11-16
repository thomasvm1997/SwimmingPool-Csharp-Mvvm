using System.ComponentModel.DataAnnotations;

namespace Pri.Identity.Fabric.Mvc.Models
{
    public class AccountRegisterViewModel
    {
        [Required]
        
        public string Username { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

    }
}
