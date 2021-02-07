using System;
using System.ComponentModel.DataAnnotations;

namespace DbEntities.Entities
{
    public class Donations
    {
        [Key]
        public int DonationId { get; set; }
        public int DonationAmount { get; set; }
        public DateTimeOffset DateReceived { get; set; }
        public DonationType DonationType { get; set; }
    }
}