namespace DbEntities.Entities
{
    public class DonationTypeEntity
    {
        public int DonationTypeId { get; set; }
        public DonationType DonationType { get; set; }
    }

    public enum DonationType
    {
        PureDonation = 0,
        SharingDonation = 1
    }
}