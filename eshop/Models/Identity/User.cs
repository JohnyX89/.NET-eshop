using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eshop.Models.Identity
{
    public class User : IdentityUser<int>
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name has to be up to 20 chars long")]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "LastName has to be up to 30 chars long")]
        public virtual string LastName { get; set; }

    }
}
