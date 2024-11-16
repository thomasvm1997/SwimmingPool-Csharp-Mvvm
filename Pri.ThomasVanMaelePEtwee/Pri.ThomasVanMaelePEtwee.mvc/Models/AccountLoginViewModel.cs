using System.ComponentModel.DataAnnotations;

namespace Pri.Identity.Fabric.Mvc.Models
{
    public class AccountLoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
