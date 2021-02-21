using System;

namespace DbEntities.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int LoggedInDevices { get; set; }
        public DateTimeOffset LastActivity { get; set; }
    }
}