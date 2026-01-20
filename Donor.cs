namespace BloodBank.Models; // This "label" must be here

public class Donor
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string BloodType { get; set; } = string.Empty;
    public List<DonationRecord> DonationHistory { get; set; } = new();

    public bool IsEligible 
    {
        get 
        {
            if (!DonationHistory.Any()) return true;
            var lastDonation = DonationHistory.Max(d => d.DonationDate);
            return (DateTime.Now - lastDonation).TotalDays >= 56;
        }
    }
}
