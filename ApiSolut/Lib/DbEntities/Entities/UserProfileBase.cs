using System;
using DbEntities.Constants;

namespace DbEntities.Entities
{
    public abstract class UserProfileBase
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageUrl { get; set; }

        public DateTime BirthDate { get; set; }

        //foreign_key
        public Gender Gender { get; set; }

        //foreign_key
        public Address Address { get; set; }
    }
}