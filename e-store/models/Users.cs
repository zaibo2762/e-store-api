using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace e_store.models
{
    public class Users : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
