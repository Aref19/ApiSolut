using System.ComponentModel.DataAnnotations;

namespace DbEntities.Entities
{
    public class UserRoles
    {
        [Key]
        public int UserRoleId { get; set; }
        public UserRoleType UserRoleType { get; set; }
    }

    public enum UserRoleType
    {
        DefaultUser = 0,
        BusinessUser = 1,
        SysAdmin = 10,
        Admin = 11
    }
}