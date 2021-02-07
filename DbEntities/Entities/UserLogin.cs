using System.ComponentModel.DataAnnotations;

namespace DbEntities.Entities
{
    public class UserLogin
    {
        [Key] public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [EmailAddress] public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //foreign_key
        public UserRoles UserRoles { get; set; }
    }
}