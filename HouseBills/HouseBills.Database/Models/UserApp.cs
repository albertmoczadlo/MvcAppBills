using Microsoft.AspNetCore.Identity;


namespace HouseBills.Domain.Models
{
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
