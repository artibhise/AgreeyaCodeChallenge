using Microsoft.AspNetCore.Identity;

namespace Repository.Models
{
    public partial class Customer : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Password { get; set; } = null!;
        public string? LoginUser { get; set; }
    }
}
